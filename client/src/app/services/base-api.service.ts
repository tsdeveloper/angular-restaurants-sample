import {Injectable} from '@angular/core';
import {Observable, Subject, throwError} from 'rxjs';
import {HttpClient, HttpHeaders, HttpParams} from '@angular/common/http';
import {environment} from '../../environments/environment';
import {catchError, map, retry} from 'rxjs/operators';
import {BaseOperationsService} from './interface/base-operations.service';


export abstract class BaseApiService<T> implements BaseOperationsService<T | null> {

  constructor(protected http: HttpClient, protected route: string) {
    this.baseUrl = `${environment.api.baseUrl}/${route}`;
    this.genericError = `Some Error occcured, Please contact Administrator for the Errors`;

  }

  genericError = '';

  protected baseUrl: string;

  protected optionsRoutes: any = {
    route: ''
  };

// Http Options
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  protected initOptionsRoute(options?: any): void {
    this.optionsRoutes = options;
    this.baseUrl += this.optionsRoutes.route;

  }

  save(params: HttpParams) {
    return this.http.post<T>(this.baseUrl, JSON.stringify(params),{
      observe: 'response', params,
        headers: this.httpOptions.headers
    });
  }

  update(params: HttpParams) {
    return this.http.put<T>(this.baseUrl, JSON.stringify(params),{
      observe: 'response', params,
        headers: this.httpOptions.headers
    });
  }

  findOne(params: HttpParams): Observable<T | null> {
    return this.http.get<T>(this.baseUrl, {
      observe: 'response', params,
      headers: this.httpOptions.headers
    }).pipe(
      map(res => {
        return res.body;
      })
    );
  }

  findAll(params?: HttpParams): Observable<T[] | null> {
  /*  return this.http.get<T[]>(this.baseUrl, {
        observe: 'response', params,
        headers: this.httpOptions.headers
      }
    ).pipe(
      map(x => x.body)
    );*/

    return this.http.get<T[]>('http://localhost:5000/api/restaurants/all-restaurants', {
      observe: 'response', params,
      headers: this.httpOptions.headers
    }).pipe(
      map(x => x.body)
    );
  }

  /*



    delete(params: HttpParams): Observable<T> {
      return this._http.delete<T>(`${this.baseUrl}/${this._route}/`  + id, this.httpOptions);
    }
  */


  // HttpClient API get() method => Fetch employees list
  /* get<T>(entity?: any): Observable<T> {
     return this._http.get<T>(this.formUrl(entity))
       .pipe(
         retry(1),
         catchError(this.handleError)
       );
   }*/

  /*// HttpClient API get() method => Fetch employee
  getEmployee(id): Observable<Employee> {
    return this.http.get<Employee>(this.apiURL + '/employees/' + id)
      .pipe(
        retry(1),
        catchError(this.handleError)
      );
  }

  // HttpClient API post() method => Create employee
  createEmployee(employee): Observable<Employee> {
    return this.http.post<Employee>(this.apiURL + '/employees', JSON.stringify(employee), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.handleError)
      );
  }

  // HttpClient API put() method => Update employee
  updateEmployee(id, employee): Observable<Employee> {
    return this.http.put<Employee>(this.apiURL + '/employees/' + id, JSON.stringify(employee), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.handleError)
      );
  }

  // HttpClient API delete() method => Delete employee
  deleteEmployee(id) {
    return this.http.delete<Employee>(this.apiURL + '/employees/' + id, this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.handleError)
      );
  }*/

  // Error handling
  handleError(error?: any): Observable<any> {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    window.alert(errorMessage);
    return throwError(errorMessage);
  }


  protected formUrl(entity?: any): string {
    let urlParams = '';

    if (entity && entity.id) {
      urlParams = `/${entity.id}`;
    }

    return this.baseUrl + this.route + urlParams;
  }

}
