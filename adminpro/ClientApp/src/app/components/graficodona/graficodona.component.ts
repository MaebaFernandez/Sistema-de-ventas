import {Component, Input, OnInit} from '@angular/core';

@Component({
  selector: 'app-graficodona',
  templateUrl: './graficodona.component.html',
})
export class GraficodonaComponent implements OnInit {

  constructor() { }
  @Input('type') doughnutcharType:string='doughnut';// tipo de garfica
  @Input('labels') doughnutchartLabels: string[]=['Hombres','Mujeres','medios'];
  @Input('data') doughnutchartData:number[]=[60,10,78];
  @Input() leyenda:string;
  ngOnInit() {
  }

}
