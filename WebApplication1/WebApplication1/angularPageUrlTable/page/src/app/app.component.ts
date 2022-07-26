import { Component, ElementRef, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UrlServiceService } from './services/url-service.service';
import Swal from 'sweetalert2';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'page';
  @ViewChild("newLink") Elem?: ElementRef;
  role = '';
  name: any;
  listOfUrls: any;
  constructor(
    private urlService: UrlServiceService,
    private route: ActivatedRoute
  ) {
    this.route.queryParams.subscribe((params) => {
      localStorage.setItem('UserName', params['name']);
      this.getAll();
    });
  }
  getAll() {
    this.urlService.GetUrlTable().subscribe({
      next: (data) => {
        console.log(data);
        this.role = data.currentRole;
        this.name = localStorage.getItem('UserName');
        this.listOfUrls = data.urlModels;
      },
      error: (error) => {
        console.log(error);
      },
    });
  }
  CreateNewUrl(url: string) {

    try {
      let tmp = new URL(url);
    } catch (_) {
      Swal.fire({
        title: 'Sorry your link is incorrect',
      })
      return;
    }


    if(this.Elem)
      this.Elem.nativeElement.value = "";
    for (let i = 0; i < this.listOfUrls.length; i++) {
      if (this.listOfUrls[i].longUrl == url || this.listOfUrls[i].shortUrl == url) {
        alert('this link already shorted');
        return;
      }
    }

    this.urlService.CreateNewUrl(url).subscribe({
      next: (data) => {
        console.log(data);
        this.role = data.currentRole;
        this.name = localStorage.getItem('UserName');
        this.listOfUrls = data.urlModels;
      },
      error: (error) => {
        console.log(error);
      },
    });

  }
  Delete(id: number) {
    this.urlService.DeleteUrl(id).subscribe({
      next: (data) => {
        console.log(data);
        this.role = data.currentRole;
        this.name = localStorage.getItem('UserName');
        this.listOfUrls = data.urlModels;
      },
      error: (error) => {
        console.log(error);
      },
    });
  }
  ShowModal(urlInfo: any) {
    Swal.fire(
      `Owner: ${urlInfo.applicationUser.userName}`,
      `Long: ${urlInfo.longUrl}\n<br>Short: ${urlInfo.shortUrl}`,
      'success'
    );
  }
}
