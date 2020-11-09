import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  eventosold: any = [
    {
      EventoId: 1,
      Tema: 'Angular',
      Local: 'Belo Horizonte'
    },
    {
      EventoId: 2,
      Tema: '.NET Core',
      Local: 'São Paulo'
    },
    {
      EventoId: 3,
      Tema: 'Angular e .NET Core',
      Local: 'Rio de Janeiro'
    },
  ]

  projetos: any = [];
  cursos: any = [];
  imagemLargura: number = 50;
  imagemAltura: number = 50;
  imagemMargem: number = 20;
  mostrarImagemProjeto: boolean = false;
  mostrarImagemCurso: boolean = false;

  constructor(
    private http: HttpClient
  ) { }


  ngOnInit(): void {
    this.getCursos();
    this.getProjetos();
  }

  alternarImagemProjeto() {
    this.mostrarImagemProjeto = !this.mostrarImagemProjeto;
  }

  alternarImagemCurso() {
    this.mostrarImagemCurso = !this.mostrarImagemCurso;
  }

  getProjetos() {
    this.projetos = this.http
      .get('http://localhost:5000/projetos')
      .subscribe(
        response => {
          console.log('response', response);
          this.projetos = response;
        },
        error => {
          console.log('error', error)
        }
      )
    ;
  }

  getCursos() {
    this.cursos = this.http
      .get('http://localhost:5000/cursos')
      .subscribe(
        response => {
          console.log('response', response);
          this.cursos = response;
        },
        error => {
          console.log('error', error)
        }
      )
    ;
  }

}
