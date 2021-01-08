import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Member } from '../_models/member';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class membersService {
  memberListChangedEvent = new Subject<Member[]>(); 
  memberSelectedEvent = new Subject<Member>(); 
  members: Member[] = [];

  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  //GET ALL members
  getMembers(){
    return this.http.get<Member[]>(this.baseUrl + 'users');
}
  //GET member BY username
  getMember(username: string) {
    return this.http.get<Member>(this.baseUrl + 'users/' + username);
  }

}
