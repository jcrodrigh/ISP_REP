import {Pipe, PipeTransform} from '@angular/core';

/*
 * Raise the value exponentially
 * Takes an exponent argument that defaults to 1.
 * Usage:
 *   value | exponentialStrength:exponent
 * Example:
 *   {{ 2 | exponentialStrength:10 }}
 *   formats to: 1024
*/
@Pipe({name: 'ColorStatusDocument'})
export class ColorStatusDocumentPipe implements PipeTransform {
  transform(value: number): string {
    switch (value) {
      case 1:case 5:
        return 'badge badge-success';
      case 2:
        return 'badge badge-secondary';
      case 3:
        return 'badge badge-success';
      case 4:
        return 'badge badge-danger';
      default:
        return '';
    }
  }
}

@Pipe({name: 'NameStatusDocument'})
export class NameStatusDocumentPipe implements PipeTransform {
  transform(value: number): string {
    switch (value) {
      case 1:case 5:
        return 'Verificado';
      case 2:
        return 'Transferido';
      case 3:
        return 'Contabilizado';
      case 4:
        return 'Rechazado';
      default:
        return '';
    } 
  }
}

@Pipe({
  name: 'ShortNameTypeDocuments',
  pure: false
})
export class ShortNameTypeDocuments implements PipeTransform {
  transform(value: string): string {
    switch (value) {
      
      case '01':
        return 'Fact.';
      case '02':
        return 'RxH';
      case '03':
        return 'Boleta';
      case '05':
        return 'Bol.Aér.';
      case '07':
        return 'NC.';
      case '08':
        return 'ND.';
      case '10':
        return 'RxArrenda';
      case '12':
        return 'Ticket.';
      case '13':
        return 'EmitxBanc.';
      case '14':
        return 'RxServPub.';
      case '50':
        return 'DUA/DAM.';
      case '91':
        return 'C No Dom.';
      case '97':
        return 'NC No Dom.';      
      case 'ER':
        return 'Entr. rendir.';
    }
  }
}



@Pipe({
  name: 'EmitTypeDocuments',
  pure: false
})
export class EmitTypeDocuments implements PipeTransform {
  transform(value: boolean): string {
    
    if (value) return 'F';
    return 'E'
  }
}

@Pipe({
  name: 'EmitTypeNegociable',
  pure: false
})
export class EmitTypeNegociable implements PipeTransform {
  transform(value: boolean): string {
    //console.log(value)
    if (value) return 'Si';
    return 'No'
  }
}
