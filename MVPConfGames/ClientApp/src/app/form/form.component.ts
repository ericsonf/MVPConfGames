import { Component, OnInit, Inject, Input } from '@angular/core';
import { NgForm } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-form-component',
  templateUrl: './form.component.html'
})

export class FormComponent implements OnInit {
  @Input() jogo: Jogo = new Jogo();
  ngOnInit() { }
  public route: string;
  public body = new FormData();
  public file: File;
  constructor(private router: Router, private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.route = baseUrl;
  }

  fileChange(event) {
    let fileList: FileList = event.target.files;
    if (fileList.length > 0) {
      this.file = fileList[0];
    }
  }

  Novo(novoJogo: NgForm) {
    this.body.append('nome', novoJogo.value.nome);
    this.body.append('lancamento', novoJogo.value.lancamento);
    this.body.append('imagem', this.file);
    this.body.append('consoleId', novoJogo.value.console);

    let headers = new HttpHeaders();
    headers.set('Content-Type', '');
    this.http.post<Jogo>(this.route + 'api/games', this.body, { headers }).subscribe(response => {
      this.router.navigate(['/'])
    }, error => console.error(error));
  }
}

class Jogo {
  id: number;
  nome: string;
  lancamento: number;
  imagem: string;
  consoleId: string;
}
