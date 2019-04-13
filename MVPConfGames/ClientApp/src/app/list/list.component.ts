import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-list-component',
  templateUrl: './list.component.html'
})
export class ListComponent {
  public jogos: Jogo[];

  constructor(private route: ActivatedRoute, http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.route.params.subscribe(params => {
      http.get<Jogo[]>(baseUrl + 'api/games/' + params.id).subscribe(result => {
        this.jogos = result;
      }, error => console.error(error));
    });
  }
} 

interface Jogo {
  id: number;
  nome: string;
  lancamento: number;
  imagem: string;
  console: string;
}

