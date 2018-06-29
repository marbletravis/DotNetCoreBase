// tslint:disable:max-line-length
// tslint:disable:member-ordering
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import * as moment from 'moment';
import { JsonSerializerSettings } from '.';
import { LoginViewModel } from '.';
import { RegisterViewModel } from '.';
import { Result } from '.';

@Injectable()
export class DataService {
	constructor(private http: HttpClient) {}

	apiRelativePath: string = 'api';

	accountApi = {
		login: (viewModel: LoginViewModel): Observable<any> => this.http.post<any>(`${this.apiRelativePath}/AccountApi/Login`, viewModel).catch(this.handleError),
		register: (model: RegisterViewModel): Observable<any> => this.http.post<any>(`${this.apiRelativePath}/AccountApi/Register`, model).catch(this.handleError),
	};

	private handleError(error: HttpErrorResponse | any) {
		let errMsg: string;
		if (error instanceof HttpErrorResponse) {
			const hdr = error.headers.get('ExceptionMessage');
			errMsg = `${error.status}${hdr ? ' - ' + hdr : ''} - ${error.statusText || ''} ${error.error}`;
		} else {
			errMsg = error.message ? error.message : error.toString();
		}
		console.error(errMsg);
		return Observable.throw(errMsg);
	}
}
