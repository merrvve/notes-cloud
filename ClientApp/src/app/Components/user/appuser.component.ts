import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, HostListener, OnInit } from '@angular/core';
import { getBaseUrl } from '../../../main';
import { LoginUserDto } from '../../Model/LoginUserDto';
import { Note } from '../../Model/Note';
import { Notebook } from '../../Model/Notebook';
import { User } from '../../Model/User';
import { UserNotebook } from '../../Model/UserNotebook';
import { AuthService } from '../../Services/auth.service';

@Component({
  selector: 'app-appuser',
  templateUrl: './appuser.component.html',
  styleUrls: ['./appuser.component.css']
})
export class AppuserComponent  {

  public selectedNoteBook: Notebook;
  public myAppUrl;
  public Notebooks: Notebook[] = [];
  public Users: User[] = [];
  public Notes: Note[] = [];
  public fileUpload: File;
  public loginUser: LoginUserDto;
  public user: User;
  public headers;
  public IsNoteBookSelected: boolean = false;
  public mobileView: boolean = false;
  public checkVisible: boolean = false;
  public nextNotebookId: number;
  public nextNoteId: number;
  public editNoteId: number = 0;
  public nextWeekplanId: number = 2;
  public editnoteText: string = "";
  public editNoteInput: string = "";
  public notebookNameVisible: boolean = true;
  public users: any[] = [];
  public searchInput: string = "";
  public searchNoteInput: string = "";
   public noteInput: string = "";
  public SortbyParam: string = "CreatedDate";
  public SortNotebyParam: string = "CreatedDate";
  public SortNoteDirection: string = "asc";
  public SortDirection: string = "desc";
  public screenHeight: number;
  public screenWidth: number;
  public selectedSticker: string = "none";
  public stickerText: string = "...";
  public stickerFilter: string = "";
  public isEdit: boolean = false;
  public activeNotes: Note[] = [];
  public selectedUsers: User[] = [];
  public searchStickerInput: string = "";
  public isLoading: boolean = true;
  public week: string[] = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"];
  public dayOfWeek = { "Sunday" : 0,"Monday" :1, "Tuesday":2, "Wednesday":3, "Thursday":4, "Friday":5, "Saturday":6 };
  public stickerTypeInt =
    {
    "none": 0,
    "primary": 1,
    "secondary": 2,
    "success": 3,
    "warning": 4,
    "danger": 5
    };

  public stickerTypeString = ["none",
    "primary",
    "secondary",
    "success",
    "warning",
    "danger"];
  public editWeekplanNote: Note = {
    hour: '',
    id: 0,
    notebookId: 0,
    textNote: '',
    day: 0,
    stickerType: 0,
    stickerNote: '...',
    createdDate: undefined,
    header: ''
  };
  public isNotebookDetail: boolean = false;


  constructor(private http: HttpClient, private auth: AuthService) {




    this.user = auth.userData;
    if (!this.user) {
      this.user = JSON.parse(localStorage.getItem("user"));
     
    }
    this.user.id = Number(localStorage.getItem("id"));
    this.user.cloudId = Number(localStorage.getItem("cloud"));
    this.myAppUrl = getBaseUrl();
    
    this.headers = { "Authorization": "Bearer " + (localStorage.getItem("token")) };

    
    this.http.get<Notebook[]>(this.myAppUrl + 'Notebook/' + this.user.id, { headers: this.headers }).subscribe(result => {
      this.Notebooks = result;

      //this.Notebooks.forEach(notebook=> );
      console.log(result);
      this.isLoading = false;
    }, error => console.error(error));

    this.onResize();
    if (this.screenWidth <= 600) {
      this.mobileView = true;
    }
    else {
      this.mobileView = false;
    }

    


  }

  @HostListener('window:resize', ['$event'])
  onResize(event?: Event) {
    this.screenHeight = window.innerHeight;
    this.screenWidth = window.innerWidth;
    if (this.screenWidth <= 600) {
      this.mobileView = true;
    }
    else {
      this.mobileView = false;
    }
  }


  onAddNoteBook(Type: number) {
    this.activeNotes = [];
   // let promptName = window.prompt("Please enter notebook name", "New Notebook");

    let notebookObject: any = {
      name: "New Notebook",
      notebookType: Type,
      createdDate: new Date(),
      modifiedDate: new Date(),
      imageCount: 0,
      textCount: 0,
      checkedCount: 0,
      uncheckedCount: 0,
      cloudId: this.user.cloudId,
      addedBy: this.user.id,
      shareStatus: 1
    }

   this.http.post(this.myAppUrl + "Notebook",
      notebookObject,
     { headers: this.headers }).subscribe(() => {
        this.Notebooks.push(notebookObject);
        this.selectedNoteBook = this.Notebooks[this.Notebooks.length - 1];
        console.log(this.Notebooks.length - 1);
        this.IsNoteBookSelected = true;
      }, error => console.error(error));

  

  }


  onDeleteAll() {
    if (window.confirm("Do you want to delete all notebooks and notes?")) {

      this.http.delete(this.myAppUrl + "Notebook/all/" + this.user.cloudId,
        { headers: this.headers }).subscribe();

      this.Notebooks = [];
      this.Notes = [];
    }
    this.IsNoteBookSelected = false;
  }

  onDeleteNotebook() {
    if (window.confirm("Delete this notebook?")) {
      this.http.delete(this.myAppUrl + "Notebook/" + this.selectedNoteBook.id,
        { headers: this.headers }).subscribe();


      this.Notes = this.Notes.filter(x => x.notebookId != this.selectedNoteBook.id);

      const index = this.Notebooks.indexOf(this.selectedNoteBook);
      if (index > -1) {
        this.Notebooks.splice(index, 1);
      }
      this.IsNoteBookSelected = false;
    }

  }


  onNotebookSetting() {

  }
  
  onEditNotebookName() {
    this.selectedNoteBook.name = window.prompt("Please enter notebook name", this.selectedNoteBook.name) || this.selectedNoteBook.name;
    this.selectedNoteBook.modifiedDate = new Date();
    this.http.put(this.myAppUrl + "Notebook",
      this.selectedNoteBook,
      { headers: this.headers }).subscribe(
     error => console.error(error));

  }

  onSelectSortParam(param: string) {
    this.SortbyParam = param;
  }

  onSelectSortNoteParam(param: string) {
    this.SortNotebyParam = param;
  }

  onSortDirection() {
    if (this.SortDirection == "asc") {
      this.SortDirection = "desc";
    }
    else if (this.SortDirection == "desc") {
      this.SortDirection = "asc";
    }
  }

  onSortNoteDirection() {
    if (this.SortNoteDirection == "asc") {
      this.SortNoteDirection = "desc";
    }
    else if (this.SortNoteDirection == "desc") {
      this.SortNoteDirection = "asc";
    }
  }

  onCloseNotebook() {
    this.IsNoteBookSelected = false;
    this.activeNotes = [];

  }





//Notes
  onStickerFilter(filter: string) {
    if (filter != "") {
      this.activeNotes = this.Notes.filter(x => x.notebookId == this.selectedNoteBook.id);
      this.activeNotes = this.activeNotes.filter(x => x.stickerType == this.stickerTypeInt[filter]);
    }
    else {
      this.activeNotes = this.Notes.filter(x => x.notebookId == this.selectedNoteBook.id);

    }

   
  }






  onAddNote(notebookId: number) {
    let noteObject : Note = {
      createdDate: new Date(),
      textNote: "sample note",
      noteType: 1,
      notebookId: notebookId
    }

    this.http.post<Note>(this.myAppUrl + "Note",
      noteObject,
      { headers: this.headers }).subscribe(result => {
        noteObject = result;
        console.log(result)
      }, error => console.error(error));
  }

  onNotebookSelect(notebookId: number) {
    this.selectedNoteBook = this.Notebooks.find(x => x.id == notebookId);
    this.updateNotes;
    this.http.get<Note[]>(this.myAppUrl + 'Note/' + notebookId, { headers: this.headers }).subscribe(result => {
      this.Notes = result;
      this.activeNotes = result;
      console.log(result);
      this.IsNoteBookSelected = true;
    }, error => console.error(error));
    
    
  }





  onNotebookDetail() {
    if (this.isNotebookDetail == true) { this.isNotebookDetail = false; }
    else { this.isNotebookDetail = true; }

  }




  //Notes Area

  onEditNote(id: number) {
    this.editnoteText = this.Notes.find(x => x.id == id).textNote;
    this.editNoteId = id;
  //  this.ChangeCheck(id);
  

  }

  onEditNoteSaveChanges() {

    this.Notes.find(x => x.id == this.editNoteId).textNote = this.editnoteText;
    this.Notes.find(x => x.id == this.editNoteId).modifiedDate = new Date();
    this.Notes.find(x => x.id == this.editNoteId).stickerType = this.stickerTypeInt[this.selectedSticker];
    this.Notes.find(x => x.id == this.editNoteId).stickerNote = this.stickerText;

    this.http.put(this.myAppUrl + "Note",
      this.Notes.find(x => x.id == this.editNoteId),
      { headers: this.headers }).subscribe(() => {
      
      this.editNoteInput = "";
      this.editnoteText = "";
      this.updateNotes();
    }, error => console.error(error));


  
  }

  ChangeCheck(id: number): void {

    if (this.Notes.find(x => x.id == id).isChecked == false) {
      this.Notes.find(x => x.id == id).isChecked = true;
      this.selectedNoteBook.checkedCount += 1;
      this.selectedNoteBook.uncheckedCount -= 1;
      this.checkVisible = true;
    }
    else if (this.Notes.find(x => x.id == id).isChecked == true) {
      this.Notes.find(x => x.id == id).isChecked = false;
      this.selectedNoteBook.checkedCount -= 1;
      this.selectedNoteBook.uncheckedCount += 1;
      this.checkVisible = false;
    }
    else { }
    this.Notes.find(x => x.id == id).modifiedDate = new Date();

    this.http.put(this.myAppUrl + "Note",
      this.Notes.find(x => x.id == id),
      { headers: this.headers }).subscribe(() => {
      this.http.put(this.myAppUrl + "Notebook",
        this.selectedNoteBook,
        { headers: this.headers } ).subscribe(() => {
      }, error => console.error(error));

    }, error => console.error(error));


   
  }



  onDeleteNote(id: number) {
    this.http.delete(this.myAppUrl + "Note/" + id,
      { headers: this.headers }).subscribe(() => {


        if (this.Notes.find(x => x.id == id).isChecked == false) {

          this.selectedNoteBook.uncheckedCount -= 1;
        }
        else if (this.Notes.find(x => x.id == id).isChecked == true) {
          this.selectedNoteBook.checkedCount -= 1;
        }


        this.http.put(this.myAppUrl + "Notebook",
          this.selectedNoteBook,
          { headers: this.headers }).subscribe(() => {
          const index = this.Notes.indexOf(this.Notes.find(x => x.id == id));
          if (index > -1) {
            this.Notes.splice(index, 1);
          }

          this.updateNotes();

        });
      });

    
   

  }

  //onAddSticker() {
  //  this.Notes.find(x => x.id == this.editNoteId).stickerType = 0;
  //  this.Notes.find(x => x.id == this.editNoteId).stickerNote = this.stickerText;
  //  this.Notes.find(x => x.id == this.editNoteId).modifiedDate = new Date();

  //  this.stickerText = "...";
  //  this.updateNotes();
  //}


  // Input Area

  public onInputSubmit() {

    if (this.noteInput != "") {

      if (this.isImage(this.noteInput)) {
        this.noteInput = "<img src='" + this.noteInput + "'>";
        this.selectedNoteBook.imageCount += 1;
      }
      else {
        this.noteInput = this.replaceURLs(this.noteInput);
        this.selectedNoteBook.textCount += 1;
      }


      let noteObject: Note = {
        createdDate: new Date(),
        textNote: this.noteInput,
        noteType: 1,
        notebookId: this.selectedNoteBook.id,
        stickerType: 0,
        isChecked: false,
        stickerNote:""
      }

      this.http.post<Note>(this.myAppUrl + "Note",
        noteObject,
        { headers: this.headers }).subscribe(result => {
          noteObject = result;
          if (this.selectedNoteBook.notebookType == 3) {

            this.selectedNoteBook.uncheckedCount += 1;
          }
          this.selectedNoteBook.modifiedDate = new Date();

          this.http.put(this.myAppUrl + "Notebook",
            this.selectedNoteBook,
            { headers: this.headers }).subscribe(() => {
            this.Notes.push(noteObject);
            this.noteInput = "";
            //   this.scroll("notes_scroll");

            this.updateNotes();
          }, error => console.error(error));
          console.log(result)
        }, error => console.error(error));

     
      
   
     
      let el = document.getElementById("inputSubmit");
      el.focus();

     
     

    }
  }

  replaceURLs(message: string) {
    var urlRegex = /(((https?:\/\/)|(www\.))[^\s]+)/g;
    return message.replace(urlRegex, function (url) {
      var hyperlink = url;
      if (!hyperlink.match('^https?:\/\/')) {
        hyperlink = 'http://' + hyperlink;
      }
      return '<a href="' + hyperlink + '" target="_blank" rel="noopener noreferrer">' + url + '</a>'
    });
  }

  isImage(url: string) {
    return /\.(jpg|jpeg|png|webp|avif|gif|svg)$/.test(url);
  }



  onFileUpload(event: Event) {
    this.fileUpload = (event.target as HTMLInputElement).files[0];
    console.log(this.fileUpload.name);


  }

  onSaveAttachment() {
    console.log(this.fileUpload.name);
  }

  onAddPlannerNote() {
    let noteObject: Note;
    if (this.isEdit == true) {
      this.Notes.find(x => x.id == this.editWeekplanNote.id).textNote = this.editWeekplanNote.textNote;
      this.Notes.find(x => x.id == this.editWeekplanNote.id).stickerType = this.stickerTypeInt[this.selectedSticker];
      this.Notes.find(x => x.id == this.editWeekplanNote.id).stickerNote = this.editWeekplanNote.stickerNote;
      this.Notes.find(x => x.id == this.editWeekplanNote.id).header = this.editWeekplanNote.header;
      this.Notes.find(x => x.id == this.editWeekplanNote.id).hour = this.editWeekplanNote.hour;
      this.Notes.find(x => x.id == this.editWeekplanNote.id).modifiedDate = new Date();
      
      noteObject = this.Notes.find(x => x.id == this.editWeekplanNote.id);
      console.log(noteObject.stickerType);

      this.http.put<Note>(this.myAppUrl + "Note",
        noteObject,
        { headers: this.headers }).subscribe(result => {
          noteObject = result;

          this.selectedNoteBook.modifiedDate = new Date();

          this.http.put(this.myAppUrl + "Notebook",
            this.selectedNoteBook,
            { headers: this.headers }).subscribe(() => {
                      }, error => console.error(error));
          console.log(result);
         
        }, error => console.error(error));


    }
    else {
      this.editWeekplanNote.textNote = this.replaceURLs(this.editWeekplanNote.textNote);

      noteObject =

      {
        
        notebookId: this.selectedNoteBook.id,
        createdDate: new Date(),
        textNote: this.editWeekplanNote.textNote,
        day: this.editWeekplanNote.day,
        stickerType: this.stickerTypeInt[this.selectedSticker],
        stickerNote: this.editWeekplanNote.stickerNote,
        hour: this.editWeekplanNote.hour,
        header: this.editWeekplanNote.header

      };
      
          this.http.post<Note>(this.myAppUrl + "Note",
        noteObject,
        { headers: this.headers }).subscribe(result => {
          noteObject = result;
         
            this.selectedNoteBook.textCount += 1;
          
          this.selectedNoteBook.modifiedDate = new Date();

          this.http.put(this.myAppUrl + "Notebook",
            this.selectedNoteBook,
            { headers: this.headers }).subscribe(() => {
            this.Notes.push(noteObject);
          
            this.updateNotes();
          }, error => console.error(error));
          console.log(result);
         
        }, error => console.error(error));
    }
  }

  onEditWeekplanNote(id: number, day: string, isEdit: boolean) {
    this.editWeekplanNote.day = this.dayOfWeek[day];
    this.editWeekplanNote.id = id;
    if (isEdit) {
      this.editWeekplanNote.id = this.Notes.find(x => x.id == id).id;
      this.editWeekplanNote.textNote = this.Notes.find(x => x.id == id).textNote;
      this.editWeekplanNote.stickerNote = this.Notes.find(x => x.id == id).stickerNote;
      this.editWeekplanNote.stickerType = this.Notes.find(x => x.id == id).stickerType;
      this.editWeekplanNote.hour = this.Notes.find(x => x.id == id).hour;
      this.editWeekplanNote.header = this.Notes.find(x => x.id == id).header;

    }

  }



  updateNotes() {
    this.activeNotes = this.Notes.filter(x => x.notebookId == this.selectedNoteBook.id);
    console.log(this.selectedNoteBook.id);

  }

  onStatusChange(status: number) {
    this.selectedNoteBook.shareStatus = status;
    this.selectedNoteBook.modifiedDate = new Date();
    if (status == 2) {
      this.http.put(this.myAppUrl + "Notebook",
        this.selectedNoteBook,
        { headers: this.headers }).subscribe((result) => {console.log(result) },error => console.error(error));

      
    }
  }

  getUsersOfNb() {
    this.http.get<User[]>(this.myAppUrl + 'UserNotebook/' + this.selectedNoteBook.id, { headers: this.headers }).subscribe(result => {
      this.selectedUsers = result;
      //this.selectedUsers = this.selectedUsers.filter(x => x.id != this.user.id);
      //this.Notebooks.forEach(notebook=> );

    }, error => console.error(error));

    this.http.get<User[]>(this.myAppUrl + 'User', { headers: this.headers }).subscribe(result => {
      this.users = result;
      this.users = this.users.filter(x => x.id != this.user.id);
      //this.Notebooks.forEach(notebook=> );
      console.log(result);
    }, error => console.error(error));
  }

  onUserSelect(user: User) {
    this.selectedUsers.push(user);
    this.users = this.users.filter(x => x.id != user.id);
    let un: UserNotebook = { userId: user.id, notebookId: this.selectedNoteBook.id }
    this.http.post<UserNotebook>(this.myAppUrl + 'UserNotebook', un, { headers: this.headers }).subscribe(result => {
      un = result;
      //this.selectedUsers = this.selectedUsers.filter(x => x.id != this.user.id);
      //this.Notebooks.forEach(notebook=> );
      console.log(result);
     
    }, error => console.error(error));

    this.http.put(this.myAppUrl + "Notebook",
      this.selectedNoteBook,
      { headers: this.headers }).subscribe((result) => { console.log(result) }, error => console.error(error));

  }

  onUserDelete(user: User) {
    if (user.id != this.user.id) {
      this.users.push(user);
      this.selectedUsers = this.selectedUsers.filter(x => x.id != user.id);
    }
    
  }

  onSelectPresentation() {
    this.auth.listSlides();
  }


  onSelectSignout() {
    this.auth.SignOut().then(() => console.log("Signout successfull"));
  }

}







