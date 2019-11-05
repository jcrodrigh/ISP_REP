import {Component, ViewChild, Input, OnInit, OnDestroy} from '@angular/core';
import {HttpRequest, HttpEventType, HttpClient} from '@angular/common/http';
import * as FileSaver from 'file-saver';
import {Enterprise, Documentx, PaymentDocumentDTO, ResultMessage2} from 'src/app/_models';
import {SwalComponent} from '@sweetalert2/ngx-sweetalert2';

import {DocumentCardComponent} from 'src/app/views/_utilitaries/document/document.component';
import { Router } from '@angular/router';
import { ModalDirective } from 'ngx-bootstrap';
import { PaymentDocumentsService } from 'src/app/_services';
const EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';

@Component({
  selector: 'documents-excel',
  templateUrl: './documents-excel.component.html',
  //styleUrls:["./documents-form.component.css"]
})
export class DocumentsExcelComponent implements OnInit {
  documentWithoutImage: Documentx[];
  //@ViewChild('UploadImage',{static: false}) public UploadImage:DocumentsExcelUploadImageComponent;
  @ViewChild('UploadImage', {static: false}) public UploadImage: DocumentCardComponent;
  
  @ViewChild('ConfirmSwal', {static: false}) private ConfirmSwal: SwalComponent;
  @ViewChild('ConfirmFinalizarSwal', {static: false}) private ConfirmFinalizarSwal: SwalComponent;
  @ViewChild('ConfirmCancelmSwal', {static: false}) private ConfirmCancelmSwal: SwalComponent;
  @ViewChild('SuccessSwal', {static: false}) private SuccessSwal: SwalComponent;
  

  @ViewChild('UploadDocumentosModal', {static: false}) private UploadDocumentosModal: ModalDirective;
  
  
  ent: Enterprise;
  vista_entrada: boolean;
  manualx: boolean;
  masivox: boolean;

  respuesta: any;

  messageError: string;

  resultmessage :ResultMessage2;

  public progress: number;
  public message: string;
  public bandera: boolean;
  public errorx: boolean;

  resultado: boolean;
  pathFile: string;

  mostrarPlantilla:boolean;
  mostrarCargaExcel : boolean;
  mostrarResultado:boolean;
  mostrarCargaImagen : boolean;


  listadocumentos : PaymentDocumentDTO[];
  public loadedImages: Array<string>;

  constructor(private http: HttpClient,private router: Router,
              private _iServicesDocument: PaymentDocumentsService,
              private _documentService: PaymentDocumentsService,) {

  }


  show() {
    console.log('entré');
    this.UploadImage.open();
  }

  documents: Documentx[];

  //****************************************** */


  ngOnInit() {
    this.vista_entrada = true;
    this.manualx = false;
    this.masivox = false;

    this.bandera = true;
    this.errorx = false;
    this.resultado = true;
    this.loadedImages = [];

     //mostramos
     this.mostrarPlantilla = true;
     this.mostrarCargaExcel = true;
     this.mostrarResultado = false;
     this.mostrarCargaImagen = false;


  }

  manual() {
    console.log('entrada');
    this.vista_entrada = false;
    this.manualx = true;
  }

  masivo() {
    this.vista_entrada = false;
    this.masivox = true;
  }

  get_ruc_client($e) {
    this.ent = $e.EnterpriseSelected;
  }

  upload(files) {
    //********** Cesar Nicolini 04/09/2019 *******/
    this.documents = null;

    //****************CN */


    if (files.length === 0) {
      return;
    }

    const formData = new FormData();
    formData.append('file', files[0]);

    const uploadReq = new HttpRequest('POST', `import/import`, formData, {
      reportProgress: true,
    });

    this.http.request(uploadReq).subscribe((event) => {
      this.bandera = false;
      console.log(event);

      if (event.type === HttpEventType.UploadProgress) {
        this.progress = Math.round(100 * event.loaded / event.total);
      } else if (event.type === HttpEventType.Response) {
        this.message = event.body.toString();
        this.respuesta = event.body;
        this.pathFile = this.respuesta.filepath;
        this.resultado = false;


        this.mostrarPlantilla = false;
        this.mostrarCargaExcel = false;
        
        this.mostrarResultado = true;
        this.mostrarCargaImagen = true;


        this.documents = this.respuesta.documents;
        if(this.documents.length>0)
        {
          this.mostrarCargaImagen=true;
        }else
        {
          this.mostrarCargaImagen = false;
        }

        //this.show();

        //***************************** */

        /*
        if (this.respuesta.okRows == 0) {
          if (this.respuesta.errorsByRow + this.respuesta.DangerRows > 0) {
            this.messageError = 'No se ha podido subir nada en lo absoluto. Más bien se han presentado ' + (this.respuesta.DangerRows + this.respuesta.errorsByRow).toString() + ' errores.';
          } else {
            this.messageError = 'El documento está practicamente vació.';
          }
          this.errorx = true;
        }
        */
        console.log(this.message);
      }

    }, (err) => {
      console.log(err);
      this.errorx = true;
    });
  }

  DescargarErrores() {

    return this.http.get<Blob>(`Document/getTemplate/` + this.pathFile,
      {responseType: 'blob' as 'json'})
      .subscribe(
        blob => {
          this.saveAsBlob(blob);
        },
        error => {
          console.log('Something went wrong');
        });
  }

  DamePlantilla() {

    return this.http.get<Blob>(`Document/getTemplate`,
      {responseType: 'blob' as 'json'})
      .subscribe(
        blob => {
          this.saveAsBlob(blob);
        },
        error => {
          console.log('Something went wrong');
        });

    /*
        this.http.get<Blob>(`Document/getTemplate`,
        { responseType: 'blob' as 'json' })
          .subscribe(blob => {
            downloadFile(blob, 'template.xlsx');
          },
          error => {
            console.log("mecmec");
          });

          let headers = new Headers();

            return this.http.get('Document/getTemplate', {

              responseType: ResponseContentType.Blob
          })
          .toPromise()
          .then(response => this.saveAsBlob(response))
          .catch(error => console.log("mecmec"));

    */
    //return this.http.get('Servers/DownloadServerList', {responseType: EXCEL_TYPE});


  }


    LimpiarControles(){
           //mostramos
     this.mostrarPlantilla = true;
     this.mostrarCargaExcel = true;
     this.mostrarResultado = false;
     this.mostrarCargaImagen = false;
    }

  private saveAsBlob(data: any) {
    const blob = new Blob([data],
      {type: EXCEL_TYPE});
    const file = new File([blob], 'template.xlsx',
      {type: EXCEL_TYPE});

    FileSaver.saveAs(file);
  }

  LimpiarFormulario(){
    alert('limpiamos controles');
  }

  
  mensajeError: string;

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


    ValidarConfirmacionCarga(){
      this.ConfirmSwal.show();
    }
    
    ConfirmarCarga(){
      this.documentWithoutImage = this.documents;
      console.log('this.documents : '+this.documents)
      this.UploadDocumentosModal.show();
    }

    CancelarCarga(){
      //No hacemos nada
    }


    ValidarFinalizarCarga(){
      this.ConfirmFinalizarSwal.show();
    }

    ConfirmarFinalizarCarga(){
      
      this._documentService.uploadDtoMasivo(this.documentWithoutImage)
      .subscribe(data => {
        this.resultmessage = data;
        console.log(data);
        
        if(this.resultmessage.code==0)
        {
          this.SuccessSwal.show();
        }

        this.UploadDocumentosModal.hide();
      }
      ,(err:any)=>
      {
        console.log(err)
        alert('ocurrió un error');
        if (err.error.errors)
        {
          console.log('mensaje error : '+err.error.errors);
        }
        else
        {
          console.log('ocurrió un error interno');
        }
      });     
    }


    CancelarFinalizarCarga(){

      this.UploadDocumentosModal.hide();
      //limpiamos el control de imagenes
      for(var i=0;i<this.documentWithoutImage.length;i++)
      {
        this.documentWithoutImage[i].url_imagen = [];
      }
    }


    ValidarCancelarCarga(){
      this.ConfirmCancelmSwal.show();
    }


  getLoadedImages(numeroserie : string,res: any) {
    console.log("numeroserie : "+numeroserie);
    console.log("res : "+res);
    //this.documentWithoutImage[3].url_imagen = urlList;
/*
    if(this.documentWithoutImage.find(x=>x.id_interno==doc.id_interno).id_interno === doc.id_interno)
    {
      var index = this.documentWithoutImage.findIndex(x=>x.id_interno == doc.id_interno);
      console.log('se asigno el valor al index: '+index);
      console.log('urlList '+urlList);
      this.documentWithoutImage[index].url_imagen = urlList;
    }
*/
  }

}


