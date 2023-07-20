


import { Injectable } from '@angular/core';
import { GoogleAuthProvider } from 'firebase/auth';
import { AngularFireAuth } from '@angular/fire/compat/auth';
import firebase from 'firebase/compat';
declare const gapi: any;

declare const google: any;

import {
  AngularFirestore,
  AngularFirestoreDocument,
} from '@angular/fire/compat/firestore';
import { User } from '../Model/User';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { getBaseUrl } from '../../main';
import { Router } from '@angular/router';
import { LoginUserDto } from '../Model/LoginUserDto';
//Simport { google } from 'googleapis';

@Injectable({
  providedIn: 'root',
})
export class AuthService {


  public userData: User = null;
  public loginUser: LoginUserDto;
  public users: User[];
  public credidential: any;
  public tokenClient: any;

  constructor(
    private router: Router,
    public afs: AngularFirestore,
    public afAuth: AngularFireAuth, // Inject Firebase auth service
    private http: HttpClient
  ) { }
  // Sign in with Google
  GoogleAuth() {
    return this.AuthLogin(new GoogleAuthProvider());


  }
  // Auth logic to run auth providers
  AuthLogin(provider: GoogleAuthProvider | firebase.auth.AuthProvider) {
    return this.afAuth
      .signInWithPopup(provider)
      .then(async (result) => {
        console.log('You have been successfully logged in!');
        this.SetUserData(result.user);
        this.credidential = result.credential;
        console.log(this.credidential);
        this.createNewGoogleSlide();
      
      })
      .catch((error) => {
        console.log(error);
      });
  }

  SetUserData(user: any) {

    this.userData = {
      uid: user.uid,
      email: user.email,
      displayName: user.displayName,
      photoURL: user.photoURL,
      emailVerified: user.emailVerified
    };
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json; charset=utf-8');
    this.http.post<any>(getBaseUrl() + "User",
      this.userData,
      { headers: headers }).subscribe(result => {
        this.loginUser = result;
        localStorage.setItem("token", result.token);
        localStorage.setItem("cloud", result.cloudId);
        localStorage.setItem("id", result.userId);
        this.router.navigate(['/appuser']);

      });
    localStorage.setItem("user", JSON.stringify(this.userData));
    
  }

  GetUserData() {
    return this.userData;
  }

  GetAllUsers() {
    this.http.get<any[]>(getBaseUrl() + 'User').subscribe(result => {
      this.users = result;


    }, error => console.error(error));
    console.log(this.users);
    return this.users;
  }

  SignOut() {
    this.router.navigate(['']);
    localStorage.removeItem("token");
    localStorage.removeItem("user");
    localStorage.removeItem("id");
    localStorage.removeItem("cloud");
    return this.afAuth.signOut().then(this.userData = null);

  }

  isLoggedIn(): boolean {
    const token = localStorage.getItem('token');
    if (token) {
      return true;
    } else {
      this.router.navigate(['/']);
      return false;
    }
  }


  createNewGoogleSlide = async ()=> {
    
      // Sign in with Google
     
      // Set up the Google Slides API client with the user's credentials
      const { access_token } = this.credidential as any;
    const CLIENT_ID = '561867051906-gv06dhbu13ikbscc3gj51smusl9iaeft.apps.googleusercontent.com';
      const CLIENT_SECRET = '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';
      const REDIRECT_URI = 'https://notescloud-tr.firebaseapp.com/__/auth/handler';

    const API_KEY = 'AIzaSyCuBfPpFq3ThyO4ODE0WjXwShYW0ssuZTQ';

   

    const DISCOVERY_DOC = 'https://www.googleapis.com/discovery/v1/apis/drive/v3/rest';
    const SCOPES = 'https://www.googleapis.com/auth/drive.metadata.readonly';

    await new Promise((resolve,reject) => gapi.load(gapi.load('client', { callback: resolve, onerror: reject })));
    await gapi.client.init({
      apiKey: API_KEY,
      discoveryDocs: [DISCOVERY_DOC],
      // NOTE: OAuth2 'scope' and 'client_id' parameters have moved to initTokenClient().
    })
      .then(function () {  // Load the Calendar API discovery document.
        gapi.client.load('https://www.googleapis.com/discovery/v1/apis/drive/v3/rest');
      });
    // Now load the GIS client
   
   
        this.tokenClient = await google.accounts.oauth2.initTokenClient({
          client_id: CLIENT_ID,
          scope: SCOPES,
          prompt: 'consent',
          callback: '',  // defined at request time in await/promise scope.
        });
    await this.tokenClient.requestAccessToken({ prompt: 'consent' });

   
      

    
    
  };

  showEvents= async ()=> {
    localStorage.setItem("response", "no res");
  // Try to fetch a list of Calendar events. If a valid access token is needed,
  // prompt to obtain one and then retry the original request.
    gapi.client.calendar.events.list({ 'calendarId': 'primary' })
      .then(calendarAPIResponse =>
        localStorage.setItem("response", calendarAPIResponse)
       )
      .then(retry => gapi.client.calendar.events.list({ 'calendarId': 'primary' }))
      .then(calendarAPIResponse => localStorage.setItem("response", calendarAPIResponse))
      .catch(err =>  localStorage.setItem("error",err));   // cancelled by user, timeout, etc.
  
  }

  

  listSlides = async () => {
    console.log("list slides");
    let response;
    gapi.load('drive', 'v2');
    await new Promise((resolve, reject) => gapi.load(gapi.load('drive', { callback: resolve, onerror: reject })));
    
      response = await gapi.client.drive.files.list({
        'pageSize': 10,
        'fields': 'files(id, name)',
      });

   
      console.log(response);
      localStorage.setItem("response", response);
    
  //  const presentation = response.result;
  //  if (!presentation || !presentation.slides || presentation.slides.length == 0) {
  //    console.log("no slides");
  //    return;
  //  }
  //  // Flatten to string to display
  //  const output = presentation.slides.reduce(
  //    (str, slide, index) => {
  //      const numElements = slide.pageElements.length;
  //      return `${str}- Slide #${index} contains ${numElements} elements\n`;
  //    },
  //    'Slides:\n');
  //  console.log(output);
  //  localStorage.setItem("output", output);
  //  return output;
  }

  revokeToken() {
    let cred = gapi.client.getToken();
    if (cred !== null) {
      google.accounts.oauth2.revoke(cred.access_token, () => { console.log('Revoked: ' + cred.access_token) });
      gapi.client.setToken('');
    }
  }

  callFunc() {
    //gapi.load('client', this.start());
  }

  

 // createNewGoogleSlide() {
   // const slides = google.slides({ version: "v1", auth: authClient });
  //const slides = gapi.slides({ version: "v1", auth: oauth2Client });

  //// Create a new presentation
  //const presentation = await slides.presentations.create({
  //  requestBody: {
  //    title: "My New Presentation",
  //  },
  //});

  //    console.log(`Created presentation with ID: ${presentation.data.presentationId}`);
  //  } catch (error) {
  //    console.error(error);
  //  }
  //}

}
