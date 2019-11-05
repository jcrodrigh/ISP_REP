import { FormGroup, FormControl, Validators } from "@angular/forms";
import { DocumentsFormService } from "./documents-form.service";
import { Document_mask } from "src/app/_models";

export class DocumentsFormValidator
{
    public InvoiceFormx:FormGroup;
    public masktemp:Document_mask;
    
    issuance_datex:string = null; //para la funcion "ExpirationDateGreaterThanIssuanceDate" 
    constructor (private _util: DocumentsFormService)
    {
        this.initMask();
    }



    
  initMask ()
  {
    this.InvoiceFormx = null;
    this.InvoiceFormx = null;
    this.InvoiceFormx = null;
    this.InvoiceFormx = null;
    var temp = new FormGroup({});
    this.InvoiceFormx = temp;
    this.InvoiceFormx.enable();
    this.masktemp = 
    {
      ruc_empresa_proveedor:false,
      id_tipo_documento:false,
      num_serie:false,
      num_correlativo:false,
      fis_elec:false,
      factura_origen_serie:false,
      factura_origen_correlativo: false, 
      
      ruc_empresa_cliente:false,
      id_orden_compra:false,
      
      id_tipo_moneda:false,
      monto_subtotal_afecto:false,
      monto_subtotal_inafecto:false,
      monto_igv:false,
      monto_isc:false,
      monto_total:false,
      
      
      fecha_emision:false,
    
    
      
      id_tipo_detracciones:false,
      factura_negociable:false,
      ceco:false,
      orden:false,
      id_tipo_documento_estado:false
    }
  }


    id_tipo_documento()
  {
    this.masktemp.id_tipo_documento = true,    
    this.InvoiceFormx.addControl("id_tipo_documento",new FormControl("",Validators.required));
    //this.InvoiceForm2.setValue({"id_tipo_documento":this.documentPay.id_tipo_documento});
  }

  num_serie()
  {
      console.log(this._util._tipoDocumento);
    this.masktemp.num_serie = true,    
    this.InvoiceFormx.addControl("num_serie",
          new FormControl("",
         ));
    if (this._util._tipoDocumento.serie_requerido || this._util._tipoDocumento.lista_serie)
    {
      this.InvoiceFormx.controls['num_serie'].setValidators([Validators.required]);
      this.InvoiceFormx.controls['num_serie'].updateValueAndValidity();
    }
    if (!this._util._tipoDocumento.lista_serie)
    { 
      this.InvoiceFormx.controls['num_serie'].setValidators([Validators.pattern(this._util._tipoDocumento.formato_serie_fisica)]);
      this.InvoiceFormx.controls['num_serie'].updateValueAndValidity();
    }
    //this.InvoiceForm2.setValue({"num_serie":this.documentPay.num_serie});
  }

  id_tipo_moneda ()
  {
    this.masktemp.id_tipo_moneda = true;    
    this.InvoiceFormx.addControl("id_tipo_moneda",
          new FormControl("",
          [Validators.required,this.currencySameWithThePurcharseOrder.bind(this)]));
  }
  num_correlativo()
  {
    this.masktemp.num_correlativo = true;  


    this.InvoiceFormx.addControl("num_correlativo",
          new FormControl("",
          [Validators.required,
            Validators.pattern(this._util._tipoDocumento.formato_correlativo)]));
    //this.InvoiceForm2.setValue({"num_correlativo":this.documentPay.num_correlativo});
  }

  ruc_empresa_cliente()
  {
    this.masktemp.ruc_empresa_cliente = true,    
    this.InvoiceFormx.addControl("ruc_empresa_cliente",new FormControl("",Validators.required));
    //this.InvoiceForm2.setValue({"ruc_empresa_cliente":this.documentPay.ruc_empresa_cliente});
  }

  ceco()
  {
    this.masktemp.ceco = true;
    this.InvoiceFormx.addControl("ceco",new FormControl(""))
  }

  orden()
  {
    this.masktemp.orden = true;
    this.InvoiceFormx.addControl("orden",new FormControl(""))
  }
 

  ceco_y_orden_requeridos (requerido : boolean = false)
  {
   
    if(requerido)
    {
      this.InvoiceFormx.controls['ceco'].markAsUntouched({onlySelf:true});      
      this.InvoiceFormx.controls['ceco'].setValidators([Validators.required]);
      this.InvoiceFormx.controls['ceco'].updateValueAndValidity();

      this.InvoiceFormx.controls['orden'].markAsUntouched({onlySelf:true});
      this.InvoiceFormx.controls['orden'].setValidators([Validators.required]);
      this.InvoiceFormx.controls['orden'].updateValueAndValidity();
    }
    else
    {
      this.InvoiceFormx.controls['ceco'].clearValidators();
      this.InvoiceFormx.controls['ceco'].updateValueAndValidity();
      this.InvoiceFormx.controls['orden'].clearValidators();
      this.InvoiceFormx.controls['orden'].updateValueAndValidity();
    }
  }

  fecha_emision()
  {
    this.masktemp.fecha_emision = true,    
    this.InvoiceFormx.addControl("fecha_emision",
            new FormControl("",
            [Validators.required,this.GreaterThanToday.bind(this)]));
  }

  monto_subtotal_afecto()
  {
    this.masktemp.monto_subtotal_afecto = true,    
    this.InvoiceFormx.addControl("monto_subtotal_afecto",
                    new FormControl(0.00,[Validators.required,
                      
                      Validators.pattern("^[0-9]{0,20}.[0-9]{0,2}$")]));
    if (this._util._tipoDocumento.valor_venta_requerido)
      this.InvoiceFormx.controls['monto_subtotal_afecto'].setValidators([Validators.min(0.01)]);
    //this.InvoiceForm2.setValue({"monto_subtotal_afecto":this.documentPay.monto_subtotal_afecto});
  }
  monto_subtotal_inafecto()
  {
    this.masktemp.monto_subtotal_inafecto = true;  
    this.InvoiceFormx.addControl("monto_subtotal_inafecto",
                  new FormControl(0.00,[Validators.required,
                    Validators.pattern("^([0-9]{0,20}.[0-9]{0,2}|0)$")]));

  
    //this.InvoiceForm2.setValue({"monto_subtotal_inafecto":this.documentPay.monto_subtotal_inafecto});
  }

  monto_igv()
  {
    
    this.masktemp.monto_igv = true;    
    this.InvoiceFormx.addControl("monto_igv",
    new FormControl(0.00,[
      Validators.pattern("^[0-9]{0,20}.[0-9]{0,2}$"),
      this.CheckCorrectIGV.bind(this)]));
    
    
    //this.InvoiceForm2.setValue({"monto_igv":this.documentPay.monto_igv});
  }

  monto_isc()
  {
    this.masktemp.monto_isc = true,    
    this.InvoiceFormx.addControl("monto_isc",new FormControl(0.00,[
      Validators.required,
      Validators.pattern("^([0-9]{0,20}.[0-9]{0,2}|0)$")]));
      
    //this.InvoiceForm2.setValue({"monto_isc":this.documentPay.monto_isc});
  }


  monto_total()
  {
    
    
    this.masktemp.monto_total = true,    
    this.InvoiceFormx.addControl("monto_total",
            new FormControl(0.00,[Validators.required,
              Validators.min(0.01),
              Validators.pattern("^[0-9]{0,20}.[0-9]{0,2}$"),
              ]));
    /*if (disabled)
    {
      console.log("monto total diable")
      this.InvoiceFormx.get("monto_total").disable();
    }
    else{
      this.InvoiceFormx.get("monto_total").enable();
    }*/
    
    //this.InvoiceForm2.setValue({"monto_total":this.documentPay.monto_total});
  }

  factura_origen_serie ()
  {
    this.masktemp.factura_origen_serie = true,    
    this.InvoiceFormx.addControl("factura_origen_serie",
            new FormControl("",[
              Validators.pattern("^(E001|F[A-Z0-9]{3}|[1-9][0-9]{0,3})$"),
              this.OriginInvoiceSerialRequired.bind(this)
              ]));

    if (this._util._tipoDocumento.factura_origen_requerido)
    {
      this.InvoiceFormx.controls['factura_origen_serie'].setValidators([Validators.required]);
      this.InvoiceFormx.controls['factura_origen_serie'].updateValueAndValidity();
    }
    //this._util._tipoDocumento.factura_origen_requerido 
  }


  factura_origen_correlativo ()
  {
    this.masktemp.factura_origen_correlativo = true,    
    this.InvoiceFormx.addControl("factura_origen_correlativo",
            new FormControl("",[
              this.OriginInvoiceCorrelativeRequired.bind(this),
              Validators.pattern("^([1-9][0-9]{0,7})$")
              ]));

    if (this._util._tipoDocumento.factura_origen_requerido)
    {
      this.InvoiceFormx.controls['factura_origen_correlativo'].setValidators([Validators.required]);
      this.InvoiceFormx.controls['factura_origen_correlativo'].updateValueAndValidity();
    }
      
  }
  

  id_orden_compra()
  {
    this.limpiar_id_orden_compra();
    this.masktemp.id_orden_compra = true;
    this.InvoiceFormx.addControl("id_orden_compra",
            new FormControl(null,[Validators.required]));
    
    this.InvoiceFormx.controls["id_orden_compra"].reset({value:null,disabled: false});
    //this.InvoiceFormx.addControl("id_orden_compra",new FormControl({value:null,disabled: false}));
    
  }

  no_mostrar_orden_de_compra ()
  {
    this.masktemp.id_orden_compra = false;
  }

  sin_id_orden_compra ()
  {
    this.limpiar_id_orden_compra();
    this._util.purcharseOrderSelected = null;
    this.InvoiceFormx.addControl("id_orden_compra",new FormControl({value:"--",disabled: true}));
    this.InvoiceFormx.controls["id_orden_compra"].reset({value:"--",disabled: true});
  }

  id_tipo_detracciones()
  {
    this.masktemp.id_tipo_detracciones = true;
    this.InvoiceFormx.addControl("id_tipo_detracciones",new FormControl(null,Validators.required));
  
  }

  factura_negociable()
  {
    this.masktemp.factura_negociable = true;
    this.InvoiceFormx.addControl("factura_negociable",new FormControl(null,Validators.required));
  }

  /*
  anticipo()
  {
    this.masktemp.anticipo = true;
    this.InvoiceFormx.addControl("anticipo",
                    new FormControl(0,[Validators.required,
                      Validators.min(0.01),
                      Validators.pattern("^[0-9]{0,20}.[0-9]{0,2}$")]));
    //this.InvoiceFormx.addControl("anticipo",new FormControl("",Validators.required));
  }*/
  
  limpiar_id_orden_compra()
  {
    if (this.InvoiceFormx.get('id_orden_compra'))
    {
      this.InvoiceFormx.removeControl('id_orden_compra');
      //this.InvoiceFormx.get('id_orden_compra').clearValidators()
      //this.InvoiceFormx.get('id_orden_compra').updateValueAndValidity();
      //this.InvoiceFormx.controls["id_orden_compra"].reset({value:"--",disabled: true})
    }
    if (this.InvoiceFormx.get('ord_comp'))
    {
      this.InvoiceFormx.get('ord_comp').clearValidators()
      this.InvoiceFormx.get('ord_comp').updateValueAndValidity();
    }
  }

  setEnterpriceIntoForm()
  {
    console.log("entré aquí");
    if(!this.InvoiceFormx) return;
    if (this.InvoiceFormx.get('ruc_empresa_cliente'))
    {
      var ent = this._util.enterpriceByRUC;
      this.InvoiceFormx.setValue({"ruc_empresa_cliente":(ent?ent.ruc_empresa:null)});
    }
  }

  public resetAllAmount ()
  {
    if (this.InvoiceFormx.controls['monto_subtotal_afecto'])
    {
      this.InvoiceFormx.controls['monto_subtotal_afecto'].patchValue(0);
      this.InvoiceFormx.controls['monto_subtotal_afecto'].markAsUntouched() ;
    }

    if (this.InvoiceFormx.controls['monto_subtotal_inafecto'])
    {
      this.InvoiceFormx.controls['monto_subtotal_inafecto'].patchValue(0);
      this.InvoiceFormx.controls['monto_subtotal_inafecto'].markAsUntouched() ;
    }

    if (this.InvoiceFormx.controls['monto_isc'])
    {
      this.InvoiceFormx.controls['monto_isc'].patchValue(0);
      this.InvoiceFormx.controls['monto_isc'].markAsUntouched() ;
    }


    this.resetIGVandTotalAmount();
    
  }

  public resetIGVandTotalAmount()
  {
    if (this.InvoiceFormx.controls['monto_igv'])
    {
      this.InvoiceFormx.controls['monto_igv'].patchValue(0);
      this.InvoiceFormx.controls['monto_igv'].markAsUntouched() ;
    }

    if (this.InvoiceFormx.controls['monto_total'])
    {
      this.InvoiceFormx.controls['monto_total'].patchValue(0);
      this.InvoiceFormx.controls['monto_total'].markAsUntouched() ;
    }
  }


  public CheckCorrectIGV (control: FormControl):{[s: string]: boolean} | null 
  {
    if (!this._util._tipoDocumento.igv_calculado) return null;
    var Afecto = (this.InvoiceFormx.get('monto_subtotal_afecto')) ? this.InvoiceFormx.get('monto_subtotal_afecto').value || 0 : 0;
    var isc = (this.InvoiceFormx.get('monto_isc')) ? this.InvoiceFormx.get('monto_isc').value || 0 : 0;
    const igvByDocument = this._util._tipoDocumento.iva;

    Afecto = Math.trunc(Afecto * 100) / 100;
    /*Inafecto = Math.trunc(Inafecto * 100) / 100;*/
    isc = Math.trunc(isc * 100) / 100;

    if (Afecto==0) return null;
    
    var total = Math.round((Afecto+isc)*igvByDocument*100)/100;
    var igv = Math.round(control.value*100)/100;

    /*
    console.log('igv por documento',igvByDocument)
    console.log('isc',isc);
    console.log('total',total);
    console.log('igv',igv)*/

    if (total!=igv)
    {
      return {'CheckCorrectIGV':true}
    }
    return null;
  } 

  public GreaterThanToday(control: FormControl):{[s: string]: boolean} | null 
   {
     var date = new Date();
     const any_date = control.value;
     const today = this._util.datePipe.transform(date, 'yyyy-MM-dd');
     const dosmil = '2000-01-01';

    console.log(control.value);

     if (any_date == null || any_date == "") return null;
     
     if((any_date !== null) && any_date > today) 
     {
       this.issuance_datex = null;
       return {'AfterToday':true};
     } 

     
     if((any_date !== null) && dosmil > any_date && any_date <= today) 
     {
       this.issuance_datex = null;
       return {'before2000':true};
     } 
     
     this.issuance_datex = any_date;
     return null;
         
   }

  
   currencySameWithThePurcharseOrder(control: FormControl):{[s: string]: boolean} | null 
   {
      var id_tipo_moneda = (this.InvoiceFormx.controls['id_tipo_moneda'])?
      this.InvoiceFormx.controls['id_tipo_moneda']:null;
      
     var po = this._util.purcharseOrderSelected;
     console.log("po del validator de la flaca:",po);
     if (po && id_tipo_moneda)
     {
      var coinSelected = control.value;
       if (po.id_orden_compra!="--" && coinSelected != po.id_tipo_moneda )
       {
        return {'coinPurcharseOrder':true};
        
       }
       return null;
     }
    return null;
   }
   

   OriginInvoiceSerialRequired (c:FormControl):{[s: string]: boolean} | null 
   {
      if (this.InvoiceFormx.get("factura_origen_correlativo")==null ) return null;
      if (this.InvoiceFormx.get("factura_origen_correlativo").value.trim()=="") return {'originInvoiceSerial':true};
      return null;
   }

   OriginInvoiceCorrelativeRequired (c:FormControl):{[s: string]: boolean} | null 
   {
    if (this.InvoiceFormx.get("factura_origen_serie")==null ) return null;
    if (this.InvoiceFormx.get("factura_origen_serie").value.trim()=="") return {'originInvoiceCorrelative':true};
    return null;
   }

   tolerancia ():boolean
   {
    var id_purcharse_order = this.InvoiceFormx.get("id_orden_compra")?
                                    this.InvoiceFormx.get("id_orden_compra").value:"";

    if (id_purcharse_order == "" || id_purcharse_order == "--" ) return false;
       
    var monto_subtotal_afecto = (this.InvoiceFormx.controls["monto_subtotal_afecto"])?this.InvoiceFormx.controls["monto_subtotal_afecto"].value || 0: 0;
    var monto_subtotal_inafecto = (this.InvoiceFormx.controls["monto_subtotal_inafecto"])?this.InvoiceFormx.controls["monto_subtotal_inafecto"].value || 0: 0;

    monto_subtotal_afecto = (monto_subtotal_afecto.value)?monto_subtotal_afecto.value:monto_subtotal_afecto;
    monto_subtotal_inafecto = (monto_subtotal_inafecto.value)?monto_subtotal_inafecto.value:monto_subtotal_inafecto;
    

    var valor_venta = monto_subtotal_afecto + monto_subtotal_inafecto;    
    var tipo_tolerancia = this._util.enterpriceByRUC.tipo_tolerancia.valueOf();
    var tolerancia = this._util.enterpriceByRUC.tolerancia;

    if (!this._util.purchaseOrders) return false;
        
    this._util.purcharseOrderSelected 
        = this._util.purchaseOrders.filter(po => po.id_orden_compra==id_purcharse_order)[0];
        if (!this._util.purcharseOrderSelected) return false;
        //obtemos el monto
        var monto_orden_compra = this._util.purcharseOrderSelected.monto_orden_compra;
        var monto_acumulado = this._util.purcharseOrderSelected.monto_acumulado;
        //el monto de la tolerancia 
        //var valor_tolerancia_minimo;
        var valor_tolerancia_maximo;
       if (tipo_tolerancia == 1)
       {
           valor_tolerancia_maximo = monto_orden_compra*(1+tolerancia.valueOf());
           //valor_tolerancia_minimo = valor_venta*(1-tolerancia.valueOf());
       }
       else if(tipo_tolerancia ==2)
       {
            valor_tolerancia_maximo = monto_orden_compra+tolerancia.valueOf();
            //valor_tolerancia_minimo = valor_venta-tolerancia.valueOf();
       }
       else 
       {
           return false;//el cliente no presenta tolerancias :V
       }

      //  console.log("monto_orden_compra",monto_orden_compra)
      //  //console.log("valor_tolerancia_minimo",valor_tolerancia_minimo)
      //  console.log("valor_tolerancia_maximo",valor_tolerancia_maximo)
      //  console.log("monto_total_factura",valor_venta)
       //if (valor_tolerancia_minimo<= monto_orden_compra && valor_tolerancia_maximo>=monto_orden_compra)
       if ( valor_tolerancia_maximo  >= valor_venta + monto_acumulado)
       {
         
           return false;
       }
       
       
       return true;
       
   }
}

