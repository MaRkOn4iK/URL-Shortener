import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UrlServiceService {

  constructor( private http: HttpClient) { }
  GetUrlTable():Observable<any>
  {
    const requestOptions: Object = {
      responseType: 'json',
    };
    
   return this.http
    .get<any>(
      `https://localhost:44347/api/Url/GetUrls/${localStorage.getItem('UserName')}`,requestOptions
    );
  }

  CreateNewUrl(url:string) : Observable<any>
  {
    
    const requestOptions: Object = {
      responseType: 'json',
    };
    console.log(localStorage.getItem('UserName'));
    
   return this.http
    .post<any>(
      `https://localhost:44347/api/Url/CreateUrl/${localStorage.getItem('UserName')}`,{url},requestOptions
    );
  }

  DeleteUrl(id:number)
  {
    const requestOptions: Object = {
      responseType: 'json',
    };
   return this.http
    .delete<any>(
      `https://localhost:44347/api/Url/DeleteUrl/${localStorage.getItem('UserName')}/${id}`,requestOptions
    );
  }
}
