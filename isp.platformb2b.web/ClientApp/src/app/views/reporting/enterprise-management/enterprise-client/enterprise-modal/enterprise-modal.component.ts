import { Component, OnInit, ViewChild } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { EnterpriceService, MasterTablesService } from 'src/app/_services';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Enterprise, EnterpriseDTO } from 'src/app/_models';
import { SwalComponent } from '@sweetalert2/ngx-sweetalert2';


@Component({
  selector: 'app-enterprise-modal',
  templateUrl: './enterprise-modal.component.html',
  styleUrls: ['./enterprise-modal.component.css']
})
export class EnterpriseModalComponent implements OnInit {

  @ViewChild('EnterpriseForm', {static: false}) private EnterpriseForm: ModalDirective;
  @ViewChild('SuccessSwal', {static: false}) private SuccessSwal: SwalComponent;
  @ViewChild('ActivateSwal', {static: false}) private ActivateSwal: SwalComponent;
  
  
  enterpriseForm: FormGroup;
  lista_erps: any[];

  upd_cre_flag:boolean = true;
  inactive_form:boolean = true;
  nueva_empresa:boolean = false;

  enterprice:Enterprise;

  constructor(private formBuilder: FormBuilder,
    private _imasterTableService :MasterTablesService,
    private _ienterpriceService:EnterpriceService) 
  { 

    this.iniciar_formulario();
  }

  ngOnInit() {
    this._imasterTableService.GetTypesEnterprisesERP()
      .subscribe(erp => {this.lista_erps = this.convert(erp),console.log('erps',this.lista_erps)});
  }

  iniciar_formulario()
  {
    this.enterpriseForm = new FormGroup({
      'ruc_empresa':new FormControl("",[Validators.required,Validators.pattern("^(1|2)0[0-9]{9}$")]),
      'razon_social':new FormControl("",[Validators.required]),
      'domicilio_fiscal':new FormControl("",[Validators.required]),
      'id_tipo_empresa_erp':new FormControl("",[Validators.required]),
    })
  }

  public crear_empresa()
  {
    console.log("mecemec")
    this.upd_cre_flag = true;
    this.nueva_empresa = true;
    this.inactive_form = true;    
    //this.iniciar_formulario();
    this.cleanEnterpriseForm();
    this.desactivar_controles();
    //this.desactivar_controles();
    this.open()
  }
  

  desactivar_controles()
  {
    this.enterpriseForm.controls["razon_social"].disable();      
    this.enterpriseForm.controls["id_tipo_empresa_erp"].disable();   
    this.enterpriseForm.controls["domicilio_fiscal"].disable();
   
  }

  activar_controles()
  {
    this.enterpriseForm.controls["razon_social"].enable();
    this.enterpriseForm.controls["id_tipo_empresa_erp"].enable();
    this.enterpriseForm.controls["domicilio_fiscal"].enable();
  }


  setEnterpriseIntoForm (ent:Enterprise)
  {
    this.enterpriseForm.controls["ruc_empresa"].patchValue(ent.ruc_empresa);
    this.enterpriseForm.controls["razon_social"].patchValue(ent.razon_social);
    this.enterpriseForm.controls["domicilio_fiscal"].patchValue(ent.domicilio_fiscal);
    this.enterpriseForm.controls["id_tipo_empresa_erp"].patchValue(ent.id_tipo_empresa_erp);
  }

  cleanEnterpriseForm()
  {
    
    this.enterpriseForm.controls["razon_social"].patchValue("");
    this.enterpriseForm.controls["domicilio_fiscal"].patchValue("");
    this.enterpriseForm.controls["id_tipo_empresa_erp"].patchValue("");
  }
  private crear()
  {
    
    this._ienterpriceService.CreateNewClient(this.enterpriseForm.value)
    .subscribe(ent=>
      { 
        //this.SuccessSwal.te
        this.SuccessSwal.type="success"
        this.SuccessSwal.title = "Felicitaciones!";
        this.SuccessSwal.text =  ent.razon_social + " forma parte de IVM.";
        setTimeout(() => {
        this.SuccessSwal.show();
      }, 500)
    },

        erro=>{
          
            //this.SuccessSwal.te
            this.SuccessSwal.type="error"
            this.SuccessSwal.title = "lo sentimos...";
            this.SuccessSwal.text = "Ocurrió un error interno."
            setTimeout(() => {
            this.SuccessSwal.show();
          }, 500);}
        );
    console.log('formulario respuesta',this.enterpriseForm.value)
    
  }

  existencia_empresa()
  {
    if (this.enterpriseForm.controls["ruc_empresa"].valid)
    {
      this.inactive_form = false;
      return;
    }
    this.inactive_form = true;

  }

  buscar_empresa ()
  {
    let ruc_empresa =  this.enterpriseForm.controls["ruc_empresa"].value;
    this._ienterpriceService.getEnterpriseByRuC(ruc_empresa)
    .subscribe(ent=>this.decisor_nueva_empresa(ent))
  }
  // var temp = this._vali.InvoiceFormx.controls['num_serie'].value;


  decisor_nueva_empresa (ent:Enterprise)
  {
    this.enterprice = ent;
    if (ent==null)
    {
      this.inactive_form = false;
      this.nueva_empresa = false;
      this.activar_controles();
      this.cleanEnterpriseForm();

    }
    else if (!ent.activo)
    {
      this.ActivateSwal.title = ent.razon_social + " está Inactiva";
      this.ActivateSwal.text = "Desea Activarla?"
      setTimeout(() => {
        this.ActivateSwal.show(); 
      }, 200);
      return;
    }
    else 
    {
      console.log("acá está el tiburón")
      this._ienterpriceService.getAllRolesByEnterprice(ent.ruc_empresa)
      .subscribe(ent=> this.decisor_roles(ent ));
      
      // if (

      // )
      // this.ActivateSwal.title = ent.razon_social + " está Inactiva";
      // this.ActivateSwal.text = "Desea Activarla?"
      // setTimeout(() => {
      //   this.ActivateSwal.show(); 
      // }, 200);
    }

  }


  decisor_roles(ent:number[])
  {
    if (ent)
    {
      ent.values;
      console.log(ent);
      console.log(ent.values);
      if (ent.includes(1))
      {
        this.SuccessSwal.type ="error"
        this.SuccessSwal.text =  this.enterprice.razon_social + " ya está como cliente.";
        this.SuccessSwal.title = "Lo sentimos..."
        setTimeout(() => {
          this.SuccessSwal.show();
        }, 200);
      }
      else if (ent.includes(2))
      {
        this.ActivateSwal.title = this.enterprice.razon_social + " es proveedor.";
        this.ActivateSwal.text = "Desea que sea Cliente?";
        setTimeout(() => {
          this.ActivateSwal.show();
        }, 200);
      }
    }
    else{
      this.ActivateSwal.title = this.enterprice.razon_social + " no cuenta con nigún rol.";
      this.ActivateSwal.text = "Desea que sea Cliente?";
      setTimeout(() => {
        this.ActivateSwal.show();
      }, 200);
    }
  }
  private actualizar()
  {
    this.nueva_empresa = false;
    this.messaje_borrar();
    let enterpricedto:EnterpriseDTO = this.enterpriseForm.value;
    this._ienterpriceService.updateEnterprice(enterpricedto);
  }

  activar_empresa()
  {
    this._ienterpriceService.ActiveClient(this.enterprice.ruc_empresa)
    .subscribe(ent=> 
      {
        this.ActivateSwal.close;
        this.SuccessSwal.type = "success";
        this.SuccessSwal.title ="Felicitaciones!";
        this.SuccessSwal.text = this.enterprice.razon_social + " es cliente de IVM";
        setTimeout(() => {
          this.SuccessSwal.show();
        }, 200);
      }
      )
  }

  public SetEnterprice (ent:Enterprise)
  {
    console.log(ent);
    console.log("ruc empresa",ent.ruc_empresa)
    this.upd_cre_flag = false;
    this.inactive_form = false;
    this.enterprice = ent;
    this.setEnterpriseIntoForm (ent);
    this.activar_controles();
    /*this.enterpriseForm = new FormGroup({
      'ruc_empresa':new FormControl({value:this.enterprice.ruc_empresa,disable:this.inactive_form},[Validators.required,Validators.pattern("^(1|2)0[0-9]{9}$")]),
      'razon_social':new FormControl(this.enterprice.razon_social,[Validators.required]),
      'domicilio_fiscal':new FormControl({value:this.enterprice.domicilio_fiscal,disable:this.inactive_form},[Validators.required]),
      'id_tipo_empresa_erp':new FormControl({value:this.enterprice.id_tipo_empresa_erp,disable:this.inactive_form},[Validators.required]),
    })*/

    

   

    this.open();
  }

  


  public open()
  {
    this.EnterpriseForm.show();
  }

  close()
  {
    this.EnterpriseForm.hide();
  }

 
  private messaje_borrar()
  {
    setTimeout(() => {
      //this.SuccessSwal.te
      this.SuccessSwal.type="error"
      this.SuccessSwal.title = "lo senti";
      this.SuccessSwal.show();
    }, 500);
    
  }

  convert(obj): any[] {
    return Object.keys(obj).map(key => ({
        Key: key,
        Value: obj[key]
        
    }));

  }
}
