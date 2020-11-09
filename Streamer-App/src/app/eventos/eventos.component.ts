import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss'],
})
export class EventosComponent implements OnInit {
  eventosold: any = [
    {
      EventoId: 1,
      Tema: 'Angular',
      Local: 'Belo Horizonte',
    },
    {
      EventoId: 2,
      Tema: '.NET Core',
      Local: 'São Paulo',
    },
    {
      EventoId: 3,
      Tema: 'Angular e .NET Core',
      Local: 'Rio de Janeiro',
    },
  ];

  
  imagemLargura: number = 50;
  imagemAltura: number = 50;
  imagemMargem: number = 20;
  mostrarImagemProjeto: boolean = false;
  mostrarImagemCurso: boolean = false;
  //filterProjetos = '';
  
  //filterCursos = '';
  projetos: any = [];
  projetosFiltrados: any = [];
  _filterProjetos: string = '';
  get filterProjetos(): string {
    return this._filterProjetos;
  }
  set filterProjetos(value: string) {
    this._filterProjetos = value;
    this.projetosFiltrados = this.filterProjetos
      ? this.filtrarProjetos(this.filterProjetos)
      : this.projetos;
  }

  cursos: any = [];
  cursosFiltrados: any = [];
  _filterCursos: string = '';
  get filterCursos(): string {
    return this._filterCursos;
  }
  set filterCursos(value: string) {
    this._filterCursos = value;
    this.cursosFiltrados = this.filterCursos
      ? this.filtrarCursos(this.filterCursos)
      : this.cursos;
  }
  constructor(private http: HttpClient) {}

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
    this.projetos = this.http.get('http://localhost:5000/projetos').subscribe(
      (response) => {
        console.log('response', response);
        this.projetos = response;
      },
      (error) => {
        console.log('error', error);
      }
    );
  }
  
  filtrarProjetos(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.projetos.filter(
      projeto => projeto.whatWillWeDo.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  filtrarCursos(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.cursos.filter(
      curso => curso.name.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  getCursos() {
    this.cursos = this.http.get('http://localhost:5000/cursos').subscribe(
      (response) => {
        console.log('response', response);
        this.cursos = response;
      },
      (error) => {
        console.log('error', error);
      }
    );
  }
}
