import {Component, ViewChild, Input, OnInit, AfterViewInit} from '@angular/core';
import {ModalDirective} from 'ngx-bootstrap/modal';
import {FormGroup, FormControl, Validators} from '@angular/forms';
import {KeysValues, Enterprise, PurchaseOrder, PaymentDocumentDTO, TypesOfDocument, detraction, SerialDocuments} from 'src/app/_models';


import {DocumentsFormValidator} from './documents-form.validation';
import {DocumentsFormService} from './documents-form.service';
import {PaymentDocumentsService} from 'src/app/_services';
import {SwalComponent} from '@sweetalert2/ngx-sweetalert2';
import {Router} from '@angular/router';
import {ErrorObserver} from 'rxjs';
import { NameOfFieldOfDocuments } from 'src/app/views/_utilitaries/document/functions/documents.names';
import { DocumentDisplayComponent } from 'src/app/views/_utilitaries/document/document-display/document-display.component';
import { format } from 'util';
import { KeyValue } from '@angular/common';

@Component({
  selector: 'documents-form',
  templateUrl: './documents-form.component.html',
  styleUrls: ['./documents-form.component.css']
})
export class DocumentsFormComponent implements OnInit{
  

  
  ngOnInit(): void {
    this.enableForm = false;
    
    
    this._util.purcharseOrderSelected = null;
    this._util.purchaseOrders = null;
    this.loadedImages = [];
    
  }



  @ViewChild('SuccessSwal', {static: false}) private SuccessSwal: SwalComponent;
  @ViewChild('deleteSwal', {static: false}) private deleteSwal: SwalComponent;
  @ViewChild('ErrorSwal', {static: false}) private ErrorSwal: SwalComponent;


  enableForm: boolean;
  

  private _vali: DocumentsFormValidator;
  public loadedImages: Array<string>;

  select: FormControl = new FormControl();
  defaultState = this.select.value;

  constructor(private _util: DocumentsFormService,
              private _documentService: PaymentDocumentsService,
              private router: Router) {
    _util.Init();
    this._vali = new DocumentsFormValidator(_util);
    
  }


  public tolerancia(): boolean {
    return this._vali.tolerancia();
  }

  public masktemp(): any {
    return this._vali.masktemp;
  }

  public InvoiceFormx(): FormGroup {
    return this._vali.InvoiceFormx;
  }

  public enterprices(): Enterprise[] {
    return this._util.enterprices;
  }

  public TypeDocumentsComplete(): TypesOfDocument[] {
    return this._util.TypeDocumentsComplete;
  }

  public purchaseOrders(): PurchaseOrder[] {
    var temp = this._util.purchaseOrders
    return temp;
  }

  public TypeCurrency(): KeysValues[] {
    return this._util.TypeCurrency;
  }

  public enterpriceByRUC(): Enterprise {
    return this._util.enterpriceByRUC;
  }

  public getAllDetractions(): detraction[] {
    return this._util.detractions;
  }

  public TypeOfDocument(): TypesOfDocument {
    return this._util._tipoDocumento;
  }

  public ActualCurrency(): string
  {
    if(this._util.purcharseOrderSelected)
    {
      return this._util.purcharseOrderSelected.id_tipo_moneda;
      
    }
    else
    {
     
      return (this._vali.InvoiceFormx.controls['id_tipo_moneda'].value||null);
      
    }
  }

  public SerialByTypeOfDoc(id_tipo_documento:string):SerialDocuments[]{
    return this._util._SerialByTypeOfDoc.filter(ser=> ser.id_tipo_documento == id_tipo_documento);
  }

  public documentPay: PaymentDocumentDTO =
    {
      ruc_empresa_proveedor: '',
      id_tipo_documento: '',
      num_serie: '',
      num_correlativo: '',
      fis_elec: true,
      factura_origen_serie:'',
      factura_origen_correlativo: '',      
      
      ruc_empresa_cliente: '',
      id_orden_compra: '',
      
      id_tipo_moneda: 'PEN',
      monto_subtotal_afecto: 0,
      monto_subtotal_inafecto: 0,
      monto_igv: 0,
      monto_isc: 0,
      monto_total: 0,
     
      
      fecha_emision: new Date(),
     
      
      id_tipo_detracciones: '',
      factura_negociable: false,
      ceco: '',
      orden:'',
      url_imagen: null,
      nombre_documento_excel:''
    };



    lockCeco ()
    {
      if (this._vali.InvoiceFormx.controls["orden"].value)
      {
        this._vali.InvoiceFormx.controls["ceco"].patchValue('--');      
        this._vali.InvoiceFormx.controls["ceco"].disable({emitEvent:false,onlySelf:false});
        this._vali.InvoiceFormx.controls["ceco"].markAsUntouched();
      }
      else
      {
        this._vali.InvoiceFormx.controls["ceco"].patchValue(null);
        this._vali.InvoiceFormx.controls["ceco"].enable();
      }
      

    }


    lockOrden()
    {
      
      if (this._vali.InvoiceFormx.controls["ceco"].value)
      {
        this._vali.InvoiceFormx.controls["orden"].patchValue('--');
        this._vali.InvoiceFormx.controls["orden"].disable({emitEvent:false,onlySelf:false});
        this._vali.InvoiceFormx.controls["orden"].markAsUntouched();
        console.log(this._vali.InvoiceFormx.controls["orden"].errors);
        
      }
      else
      {
        this._vali.InvoiceFormx.controls["orden"].patchValue(null);
       
        this._vali.InvoiceFormx.controls["orden"].enable();
        
      }
    }

  SelectEnterprice(empresa_cliente:string) {
    this._util.enterpriceByRUC = this._util.enterprices.find(ent=>ent.ruc_empresa==empresa_cliente);
    console.log(empresa_cliente)
    console.log(this._util.enterprices)
    console.log('empresa mecmec',this._util.enterprices.find(ent=>ent.ruc_empresa==empresa_cliente) );

    if (!this._util.enterpriceByRUC) {
      this.ResetAllField();
      return;
    }
    if (this._util._tipoDocumento.orden_compra_requerido)
    {
      if (this._util.enterpriceByRUC.con_pedido) 
      {
        this._util.purchaseOrderService
          .getPurchaseOrderByClient(this._util.enterpriceByRUC.ruc_empresa)
          .subscribe(po => {
            this._util.purchaseOrders = po;
            
          });
        this._vali.id_orden_compra();
        this._vali.ceco_y_orden_requeridos(false);
      } 
      else {
        this._vali.sin_id_orden_compra();
        this._vali.ceco_y_orden_requeridos(true);
      }
    }
    else
    {
      this._vali.sin_id_orden_compra();
      this._vali.ceco_y_orden_requeridos(false);
    }
    
  }

  SelectTypeDocument(id_tipo_documento: string) {
    
    this.enableForm = false;
    this._util._tipoDocumento =
      this._util.TypeDocumentsComplete.filter(doc => doc.id_tipo_documento == id_tipo_documento)[0];
    console.log(this._util._tipoDocumento);
    
    this._vali = new DocumentsFormValidator(this._util);
    if (!this._util._tipoDocumento) {
      this.ResetAllField();
      return;
    }
    this._vali.InvoiceFormx = null;
    this._vali.InvoiceFormx = new FormGroup({});
    this._vali.num_serie();
    this._vali.num_correlativo();
    this._vali.fecha_emision();
    this._vali.id_tipo_moneda();
    this._vali.ruc_empresa_cliente();
    this._vali.no_mostrar_orden_de_compra();

    this._vali.InvoiceFormx.addControl('id_tipo_documento', new FormControl(id_tipo_documento));


    this._vali.monto_total();
    this._vali.monto_subtotal_afecto();

    if (!this._util._tipoDocumento.valor_venta_requerido)
    {
      this._vali.monto_igv();
      this._vali.monto_subtotal_inafecto();
    }

    //factura negociable
    if (this._util._tipoDocumento.factura_negociable)
      this._vali.factura_negociable();

    //detracciones
    if (this._util._tipoDocumento.detraccion)
      this._vali.id_tipo_detracciones();

    //monto isc
    if(this._util._tipoDocumento.monto_isc)
      this._vali.monto_isc();

    //factura origen
    if (this._util._tipoDocumento.factura_origen)
    {
      this._vali.factura_origen_serie();
      this._vali.factura_origen_correlativo();
    }

    if (this._util._tipoDocumento.orden_compra_requerido)
    {
      this._vali.ceco();
      this._vali.orden();
    }

    /*
    switch (id_tipo_documento) {
      // case'00': //otros
      //   this._vali.monto_total();
      //   this.enable_total = true;

      //   break;
      case'01': //factura
        this._vali.monto_subtotal_afecto();
        this._vali.monto_subtotal_inafecto();
        this._vali.monto_igv();
        this._vali.id_tipo_detracciones();
        this._vali.monto_isc();
        this._vali.monto_total();
        this._vali.factura_negociable();

        break;
      case'02': //rxh
        this._vali.monto_subtotal_afecto();
        //this._vali.monto_subtotal_inafecto();
        //this._vali.monto_igv(true);
        this._vali.monto_total();
        break;
      case'03': //baloeta de venta
        this._vali.monto_subtotal_afecto();
        this._vali.monto_total();

        break;
      case'05': //boletos de transporte aereos :V
        this._vali.monto_subtotal_afecto();
        this._vali.monto_subtotal_inafecto();
        
        this._vali.monto_igv();
        this._vali.monto_total();

        break;
      case'07': //nota de debito
        this._vali.factura_origen_serie();
        this._vali.factura_origen_correlativo();
        this._vali.monto_subtotal_afecto();
        this._vali.monto_subtotal_inafecto();
        this._vali.monto_igv();
        this._vali.monto_isc();
        this._vali.monto_total();
        break;
      case'08': //nota de debito
        this._vali.factura_origen_serie();
        this._vali.factura_origen_correlativo();
        this._vali.monto_subtotal_afecto();
        this._vali.monto_subtotal_inafecto();
        this._vali.monto_igv();
        this._vali.monto_isc();
        this._vali.monto_total();
        break;
      case'10'://10 – Recibo de Arrendamiento
        this._vali.monto_subtotal_afecto();
        this._vali.monto_total();
        break;
      case'12':
        this._vali.monto_subtotal_afecto();
        this._vali.monto_subtotal_inafecto();
        this._vali.monto_igv();
        this._vali.monto_total();
        break;
      case'13':
        this._vali.monto_subtotal_afecto();
        
        this._vali.monto_igv();
        this._vali.monto_total();
        break;
      case'14':
        this._vali.monto_subtotal_afecto();
        
        this._vali.monto_igv();
        this._vali.monto_total();
        break;
      case'50'://50 - Declaración Única de Aduanas - Importación definitiva    
        this._vali.monto_subtotal_afecto();
        
        this._vali.monto_isc();
        this._vali.monto_igv();
        this._vali.monto_total();
        break;
      case'91':
        // this._vali.factura_origen_serie();
        // this._vali.factura_origen_correlativo();
        this._vali.monto_subtotal_afecto();
        this._vali.monto_total();
        break;
      case'97':
        this._vali.factura_origen_serie();
        this._vali.factura_origen_correlativo();
        this._vali.monto_subtotal_afecto();
        this._vali.monto_total();
        break;
      
      case'ER':
        

        this._vali.monto_total();
        this._vali.anticipo();
        break;
    }
    */
    
    

    

    this.enableForm = true;
  }

  SelectPurcharseOrder(id_oc:any)
  {
    
    var oc = this._util.purchaseOrders.find(po => po.id_orden_compra==id_oc);
    
    
    console.log("purcharse order:",id_oc);
    console.log("lo que entró en el select ",oc);  
    
    if (oc)
    {
      /*this._vali.InvoiceFormx.controls['id_tipo_moneda'].disable();
      this._vali.InvoiceFormx.controls['id_tipo_moneda'].setValue(oc.id_tipo_moneda);*/
      this._vali.resetAllAmount ();
      this._util.purcharseOrderSelected = oc;
      var id_tipo_moneda = this._vali.InvoiceFormx.controls['id_tipo_moneda'].value;
      this._vali.InvoiceFormx.controls['id_tipo_moneda'].patchValue(id_tipo_moneda);
      this._vali.InvoiceFormx.controls['id_tipo_moneda'].updateValueAndValidity();
      console.log("mecmec entró ",id_tipo_moneda)
    }
    else
    {
      
      /*this._vali.InvoiceFormx.controls['id_tipo_moneda'].enable();*/
      this._util.purcharseOrderSelected = null;
      var id_tipo_moneda = this._vali.InvoiceFormx.controls['id_tipo_moneda'].value;
      this._vali.InvoiceFormx.controls['id_tipo_moneda'].patchValue(id_tipo_moneda);
      this._vali.InvoiceFormx.controls['id_tipo_moneda'].updateValueAndValidity();
      console.log("mecmec entró ",id_tipo_moneda);
      

    }
    var id_tipo_moneda = this._vali.InvoiceFormx.controls['id_tipo_moneda'].value;
    this._vali.InvoiceFormx.controls['id_tipo_moneda'].patchValue(id_tipo_moneda);
    this._vali.InvoiceFormx.controls['id_tipo_moneda'].updateValueAndValidity();
    
  }

  


  applySerialMask()
  {
    
    var temp = this._vali.InvoiceFormx.controls['num_serie'].value;

    temp = String(parseInt(temp))
    
    
    var num_mask = this._util._tipoDocumento.mascara_serie_fisica;
    
    if ( num_mask >0 && num_mask>=temp.length)
    {
      
      this._vali.InvoiceFormx.controls['num_serie'].patchValue('0'.repeat(num_mask-temp.length)+temp);
    } 
     
  }

  applyCorrelativeMask()
  {
    var temp = this._vali.InvoiceFormx.controls['num_correlativo'].value;

    temp = String(parseInt(temp))
    
    
    var num_mask = this._util._tipoDocumento.mascara_correlativo;
    
    if ( num_mask>0 && num_mask>=temp.length )
    {
      
      this._vali.InvoiceFormx.controls['num_correlativo'].patchValue('0'.repeat(num_mask-temp.length)+temp);
    } 
  }

  subir_sin_orden(event: any) {

    if (event) {
      //console.log("habilidao")
      this._vali.sin_id_orden_compra();
      
      this._vali.InvoiceFormx.addControl('id_orden_compra',
        new FormControl({value: '--', disabled: true}));
      /*this._vali.InvoiceFormx.addControl('id_tipo_moneda',
        new FormControl({value: null, disabled: false}))*/
      this._vali.ceco_y_orden_requeridos(true);

    } else {
      /*this._vali.InvoiceFormx.addControl('id_tipo_moneda',
        new FormControl({value: null, disabled: true}))*/
      this._vali.id_orden_compra();
      this._vali.ceco_y_orden_requeridos(false);
    }
    //this.bloquear_orden = event;
    ////console.log( this.bloquear_orden)
    //console.log(this._vali.InvoiceFormx.value)

  }

  CalculateTotalAmount(IsIGV:boolean=false) {


    var Afecto = (this._vali.InvoiceFormx.get('monto_subtotal_afecto')) ? this._vali.InvoiceFormx.get('monto_subtotal_afecto').value || 0 : 0;
    var Inafecto = (this._vali.InvoiceFormx.get('monto_subtotal_inafecto')) ? this._vali.InvoiceFormx.get('monto_subtotal_inafecto').value || 0 : 0;
    var isc = (this._vali.InvoiceFormx.get('monto_isc')) ? this._vali.InvoiceFormx.get('monto_isc').value || 0 : 0;
    var igv = (this._vali.InvoiceFormx.get("monto_igv"))?this._vali.InvoiceFormx.get("monto_igv").value || 0: 0;
    //var isc = (this._vali.InvoiceFormx.get('monto_isc')) ? this._vali.InvoiceFormx.get('monto_isc').value || 0 : 0;
    //var isc= (this._vali.InvoiceFormx.get("monto_isc"))?this._vali.InvoiceFormx.get("monto_isc").value || 0: 0;

    
    //var igv = Math.round((Afecto + isc) * (igvByDocument) * 100) / 100;

    //var total = Afecto + Inafecto  + isc;
    if (this._vali.InvoiceFormx.get('monto_igv')&& !IsIGV) {
      this._vali.InvoiceFormx.patchValue({'monto_igv': 0});
    }

    this._vali.InvoiceFormx.patchValue(
      {
        'monto_total': Math.round((Afecto + Inafecto + igv + isc) * 100) / 100,
      });

  }


  ResetAllField() {
    this._util.enterpriceByRUC = null;
    this._util.purcharseOrderSelected = null;
    this._util.purchaseOrders = null;
    this._vali.no_mostrar_orden_de_compra();
    this._vali.sin_id_orden_compra();
  }

  LimpiarControles(){
    this.select.reset(this.defaultState);
    this.loadedImages = [];
    this._vali.InvoiceFormx.reset();
  }

  onSubmit3() {

    this.documentPay = this._vali.InvoiceFormx.getRawValue();
    let arr = this.loadedImages;
    this.documentPay.fis_elec = true;
    this.documentPay.url_imagen = arr;
    console.log(this.documentPay.url_imagen);
    this.deleteSwal.show();

  }

  mensajeError: string;
  mensajeExito: string;
  ConfirmSubmit() {
    //console.log("mecmec",this.documentPay);
    console.log('mecmec', this.documentPay);
    this._documentService.uploadDto(this.documentPay).subscribe(po => {
        console.log(po);
        this.mensajeExito = "Se generó el correlativo # " + String(po.id_interno);
        
        //cambio aqui
        this.enableForm = false;

        setTimeout(() => {
          this.SuccessSwal.show();
        }, 500);
        
      }
      ,(err:any)=>
      {
        console.log(err)
        
        if (err.error.errors)
        {
          console.log('mecmec entró',err.error.errors)
          //this.errors = err.error.errors;
          this.mensajeError = this.mensaje_Error(err.error.errors);
          setTimeout(() => {
            this.ErrorSwal.show();
          }, 500);
        }
        else
        {
          this.mensajeError = 'ocurrió un error interno';
          setTimeout(() => {
            this.ErrorSwal.show();
          }, 800);
        }
        
        
      });
  }

  changeRoute() {
    this.router.navigate(['./DocumentosPago/tabla']);
  }


  private mensaje_Error (errorsx):string
  {
    
    var temp = '<dl class=row>';

    for (var key in errorsx)
    {
      temp = temp + '<dt class = col-md-3>'+NameOfFieldOfDocuments(key)+'</dt>'
      temp = temp + '<dd class = col-md-9>'
      for (var i=0; i<errorsx[key].length ; i++)
      {
        temp = temp + errorsx[key][i] + '<br>'
      }
      temp = temp + '</dd>'
      temp = temp + '<hr>'
    }
    
    temp = temp + '</dl>'
    return temp;
  }
  
  getLoadedImages(res: any) {
    console.log(res.url_imagen);
    this.loadedImages = res.url_imagen;
  }
}




