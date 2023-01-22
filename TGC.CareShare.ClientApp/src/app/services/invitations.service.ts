import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { protectedResources } from '../auth-config';
import { IHttpService } from './IHttpService';

export interface IInvitations {
  id: number;
  description: string;
  status: boolean;
}

@Injectable({
    providedIn: 'root'
})

export class InvitationService implements IHttpService  {
    url = protectedResources.apiTodoList.endpoint;

    constructor(private http: HttpClient) { }
    EndpointController: string = this.url+"/invitations";

    getRecieved() {
        return this.http.get<IInvitations[]>(this.EndpointController+"/Received");
    }

    getSent() {
        return this.http.get<IInvitations[]>(this.EndpointController+"/sent");
    }

    getById(id:string) {
        return this.http.get<IInvitations[]>(this.EndpointController+"/"+id);
    }

    Create(invitation: IInvitations) {
        return this.http.post(this.url + '/', invitation);
    }

    Update(invitation: IInvitations) {
        return this.http.put<IInvitations>(this.url + '/' + invitation.id, invitation);
    }
}
