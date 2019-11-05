import {Injectable} from '@angular/core';
import {Subject} from 'rxjs';

@Injectable()
export class LoaderService {
  isLoading = new Subject<boolean>();

  show() {
    console.log('Inicia spinner');
    this.isLoading.next(true);
  }

  hide() {
    console.log('Finaliza spinner');
    this.isLoading.next(false);
  }
}
