import {AfterContentInit, Component, Input, OnInit} from '@angular/core';
import {Document_mask, Documentx, TypesOfDocument} from 'src/app/_models';
import {getMaskbyIdDocument} from '../functions/documents.mask';
import { MasterTablesService } from 'src/app/_services';

@Component({
  selector: 'document-data',
  templateUrl: './document-data.component.html',
  styleUrls:["./document-data.component.css"]
})
export class DocumentDataComponent implements AfterContentInit,OnInit {
  

  @Input() documentWithoutImage: Documentx;
  @Input() showButtons = true;
  invoiceForm: Document_mask;
  _mascara: TypesOfDocument;
  _typeOfDocuments: TypesOfDocument[] = [];

  constructor(private _TypeOfdocumentService:MasterTablesService,
    ) {
      _TypeOfdocumentService.getAllTypeDocumentComplete()
        .subscribe(typ =>
           {this._typeOfDocuments = typ;
            console.log('mecmec recibio',this._typeOfDocuments)} );

  }


  ngOnInit(): void {
    if (this._typeOfDocuments.length ==0 )
    {
      this._TypeOfdocumentService.getAllTypeDocumentComplete()
      .subscribe(typ =>
         {this._typeOfDocuments = typ;
          this.getByTypeOfDocument ();
          console.log('mecmec recibio',this._typeOfDocuments)} );
    }
    else
    {
      this.getByTypeOfDocument ()
    }
  }
  

  ngAfterContentInit(): void {
    console.log(this.documentWithoutImage);
    /*this._mascara = this._typeOfDocuments.find(typ => typ.id_tipo_documento == this.documentWithoutImage.id_tipo_documento)[0];
    this.invoiceForm = getMaskbyIdDocument(this.documentWithoutImage.id_tipo_documento);*/
  }

  getByTypeOfDocument ()
  {
    console.log('ingreso a mecmec', this._typeOfDocuments)
    this._mascara = this._typeOfDocuments.filter(typ => typ.id_tipo_documento == this.documentWithoutImage.id_tipo_documento)[0];
    console.log('la mascara es:', this._mascara)
  }


}
