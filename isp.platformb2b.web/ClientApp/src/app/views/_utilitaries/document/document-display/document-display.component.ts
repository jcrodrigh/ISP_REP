import {Component, ViewChild, Input, OnInit, Output, EventEmitter, OnDestroy} from '@angular/core';
import {ModalDirective} from 'ngx-bootstrap/modal';
import {FormGroup, FormControl} from '@angular/forms';
import {Documentx, DocumentFile} from 'src/app/_models';
import * as FileSaver from 'file-saver';

import {PaymentDocumentsService} from 'src/app/_services';
import {SwalComponent} from '@sweetalert2/ngx-sweetalert2';
import {Router} from '@angular/router';
//import { timingSafeEqual } from 'crypto';

@Component({
  selector: 'document-display',
  templateUrl: './document-display.component.html',
  styleUrls: [`./document-display.component.css`],

})
export class DocumentDisplayComponent implements OnDestroy {
  ngOnDestroy(): void {
    this.url_imagen=[];
  }

  ruta_imagenftp : DocumentFile;
  messageError: string;
  //public url_imagen:string[];
  //url_imagen: string[]
  //si el documento ya existe
  //@Input() doc: Documentx;
  //si el documento no existe
  @Input() url_imagen: string[];

  @Input() index :string;


  public setUrlImagen(arr: string[])
  {
    this.url_imagen = arr;
  }

  @Output() emmiter = new EventEmitter();


  doc: Documentx;

  get allowDay(): Documentx {
    return this.doc;
  }

  @Input('doc')
  set allowDay(value: Documentx) {
    this.doc = value;
    this.url_imagen = value.url_imagen;
  }

  @ViewChild('SuccessSwal', {static: false}) private SuccessSwal: SwalComponent;
  @ViewChild('deleteSwal', {static: false}) private deleteSwal: SwalComponent;
  @ViewChild('ErrorSwal', {static: false}) private ErrorSwal: SwalComponent;

  //@Input() id_internal: number;

  constructor(private _iServiceDocument: PaymentDocumentsService) {

    //this.url_imagen = this.doc.url_imagen;
  }

  public ok(): string[] {
    if (this.doc) {
      return this.doc.url_imagen;
    } else {
      return this.url_imagen;
    }
  }

  saludos() {
    console.log(this.url_imagen);
  }

  getFileDetails(e) {
    
    var n = this.getNumberOfAccumulatedImage(e);

    if (n > 5) {

      this.messageError = 'No debe sobrepasar los 5 documentos';
      setTimeout(() => {
        this.ErrorSwal.show();
      }, 500);
      return;
    }


    const frmData = new FormData();
    for (var i = 0; i < e.target.files.length; i++) {
      frmData.append('files'+i, e.target.files[i]);
    }

    this.sendImage(frmData);

  }

  delete(namefile: string) {
    if (this.doc)
    {
      this._iServiceDocument.DeleteImage(String(this.doc.id_interno), namefile)
      .subscribe(doc => this.doc.url_imagen = doc);
    }
    else
    {
      for( var i = 0; i < this.url_imagen.length; i++){ 
        if ( this.url_imagen[i] === namefile) {
          this.url_imagen.splice(i, 1); 
          i--;
        }
     }
    }
    
  }

  private getNumberOfAccumulatedImage(e): Number {
    if (this.doc) {
      return this.doc.url_imagen.length + e.target.files.length;

    } else {
      return this.url_imagen.length + e.target.files.length;
    }
  }

  private sendImage(frmData: any) {
    if (this.doc) {
      this._iServiceDocument.UploadImages(String(this.doc.id_interno), frmData).subscribe(
        img => {
          console.log('entré acá');
          this.url_imagen = img;
          this.doc.url_imagen = img;
          console.log(this.url_imagen);
        });
    } else {
      this._iServiceDocument.UploadImagesWithoutDocument(frmData).subscribe(
        img => {
          img.forEach(im=> 
            {
              console.log("imagen", im)
              this.url_imagen.push(im);
              //this.emmiter.emit(this.url_imagen);
              this.emmiter.emit({url_imagen:this.url_imagen,index:this.index});
            }
          )

        }
      );
    }
  }

  descargarPDF(nombre_file:string){

    console.log('base64 : '+nombre_file);

    if(this.doc!=undefined)
    {
      if(this.doc.fis_elec==false)
      {
        //llamamos al servicio para crear
        this._iServiceDocument.GetUrlDocumentSftp(nombre_file,this.doc.id_tipo_documento).subscribe(ruta=>
          {
            if(ruta.code==0)
            {
              this.ruta_imagenftp = ruta.content;
              console.log('documento ftp : '+this.ruta_imagenftp);
  
              //var pdf = 'data:application/pdf;base64,' +this.ruta_imagenftp.data;       
              const linkSource = `data:${this.ruta_imagenftp.content_type};base64,${this.ruta_imagenftp.data}`;
              const downloadLink1 = document.createElement("a");
              downloadLink1.href = linkSource;
              downloadLink1.download = this.ruta_imagenftp.nombre_file;
              downloadLink1.click();
            }else{
              alert(ruta.message);
            }
  
        });
      }
      else
      {
        const linkSource = "/document/imagen/"+nombre_file;
        const downloadLink = document.createElement("a");
        const fileName = nombre_file;
  
        downloadLink.href = linkSource;
        downloadLink.download = nombre_file;
        downloadLink.click();
  
      }

    }else{
      const linkSource = "/document/imagen/"+nombre_file;
      const downloadLink = document.createElement("a");
      const fileName = nombre_file;

      downloadLink.href = linkSource;
      downloadLink.download = nombre_file;
      downloadLink.click();
    }


  }

}
