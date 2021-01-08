import { Photo } from "./photo";

 
export interface Member {                                       // export / Member
    id: number;
    userName: string;
    photoUrl: string;
    age: number;
    knownAs: string;
    created: Date;                                                      // changed to Date type
    lastActive: Date;                                                  // changed to Date type
    gender: string;
    introduction: string;
    lookingFor: string;
    interests: string;
    city: string;
    country: string;
    photos: Photo[];
  }
  
// moved photo to new .ts file