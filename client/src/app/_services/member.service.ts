import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Member } from '../_models/member';
import { of, Subject } from 'rxjs';
import { map } from 'rxjs/operators';

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
    if(this.members.length > 0) return of(this.members);
    return this.http.get<Member[]>(this.baseUrl + 'users').pipe(
      map(members => {
        this.members = members;
        return this.members;
      })
    )
}
  //GET member BY username
  getMember(username: string) {
    const member = this.members.find( x => x.userName === username);
    if(member !== undefined) return of(member);
    return this.http.get<Member>(this.baseUrl + 'users/' + username);
  }

  //Post update member
  updateMember(member: Member)
  {
    return this.http.put<Member>(this.baseUrl + 'users', member).pipe(
      map( () => {
        const index = this.members.indexOf(member);
        this.members[index] = member;
      })
    );
  }

  setMainPhoto(photoId: number) 
  {
    return this.http.put(this.baseUrl + 'users/set-main-photo/' + photoId, {});
  }

  deletePhoto(photoId: number) {
    return this.http.delete(this.baseUrl + 'users/delete-photo/' + photoId);
  }

}
