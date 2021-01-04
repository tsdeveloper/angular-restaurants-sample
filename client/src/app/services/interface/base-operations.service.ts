import { Injectable } from '@angular/core';
import {Observable} from 'rxjs';
import {HttpParams} from '@angular/common/http';

export interface BaseOperationsService<T> {

  save(params?: HttpParams): Observable<T | null>;
  /*update(params: HttpParams): Observable<T>;*/
  findOne(params?: HttpParams): Observable<T | null>;
  findAll(params?: HttpParams): Observable<T[] | null>;
  /*
  delete(params: HttpParams): Observable<any>;*/

}
