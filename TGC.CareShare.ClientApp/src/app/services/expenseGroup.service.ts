import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { protectedResources } from '../auth-config';
import { IHttpService } from './IHttpService';

export interface IExpenseGroup {
  id: number;
  description: string;
  status: boolean;
}

@Injectable({
    providedIn: 'root'
})

export class ExpenseGroupService implements IHttpService  {
    url = protectedResources.apiTodoList.endpoint;

    constructor(private http: HttpClient) {

    }
    
    EndpointController: string = this.url + "/expensegroup";

    getAll() {
        return this.http.get<any[]>(this.EndpointController+"/details");
    }

    getById(id:string) {
        return this.http.get<IExpenseGroup[]>(this.EndpointController+"/"+id);
    }

    Create(invitation: IExpenseGroup) {
        return this.http.post(this.url + '/', invitation);
    }
}
