import { Pipe, PipeTransform } from '@angular/core';

@Pipe({name: 'GetSymbolOfCurrency'})
export class GetSymbolOfCurrency implements PipeTransform {
  transform(value: string): string {
    switch (value) {
        case 'PEN':
            return "S/"; 
        case 'USD':
            return "$"; 
        case 'EUR':
            return "€";    
        default:
            return "*";
    }
  }
}