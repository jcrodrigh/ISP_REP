import { NgModule } from "@angular/core";
import { ColorStatusDocumentPipe, NameStatusDocumentPipe ,ShortNameTypeDocuments,GetSymbolOfCurrency, EmitTypeNegociable} from "./";
import { EmitTypeDocuments } from "./";


@NgModule({
    declarations: [ ColorStatusDocumentPipe,
        NameStatusDocumentPipe,
        ShortNameTypeDocuments,
        GetSymbolOfCurrency,
        EmitTypeDocuments,
        EmitTypeNegociable
     ],
    exports:    [ ColorStatusDocumentPipe,
        NameStatusDocumentPipe,
        ShortNameTypeDocuments,
        GetSymbolOfCurrency ,
        EmitTypeDocuments,
        EmitTypeNegociable]
  })
  export class _PipeModule { }