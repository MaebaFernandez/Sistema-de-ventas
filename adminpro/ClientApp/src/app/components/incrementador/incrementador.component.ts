import {Component, OnInit, Input, Output, EventEmitter, ViewChild, ElementRef} from '@angular/core';

@Component({
  selector: 'app-incrementador',
  templateUrl: './incrementador.component.html',
  styles: []
})
export class IncrementadorComponent implements OnInit {
  // @ts-ignore
  @ViewChild('txtProgress') txtProgress: ElementRef;
  @Input('nombre') leyenda: string;
  @Input() progreso: number;
  @Output() cambioValor: EventEmitter<number> = new EventEmitter();

  constructor() {
    this.leyenda = 'Leyenda';
    this.progreso = 20;
  }

  ngOnInit() {
  }

  sumarProgreso(value: number) {
    if (this.progreso >= 100 && value>0) {
      this.progreso = 100;
      return ;
    }
    if (this.progreso <= 0 && value<0) {// lo vuelmo a sumar por que -*-  se suma
      this.progreso = 0;
      return 0 ;
    }
    this.progreso += value;
    this.cambioValor.emit(this.progreso); // con esto estamos mandado el valor al otro componente
this.txtProgress.nativeElement.focus();
    console.log(this.progreso);
  }

  onChanges(newNumber: number) {
    // let elemHTML:any=document.getElementsByName('progreso')[0];
    console.log(this.txtProgress);
    // console.log(elemHTML);
    //  console.log(newNumber);
    if (newNumber >= 100 ) {
       this.progreso = 100;
     }else if (newNumber <= 0 ) {
       this.progreso = 0;
     }else{
       this.progreso = newNumber;
     }
    // elemHTML.value=this.progreso;
    this.txtProgress.nativeElement.value=this.progreso;
    this.cambioValor.emit(this.progreso);
  }
}
