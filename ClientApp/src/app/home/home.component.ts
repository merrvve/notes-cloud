import { Component, HostListener } from '@angular/core';
import { Router } from '@angular/router';
import { Note } from '../Model/Note';
import { Notebook } from '../Model/Notebook';
import { User } from '../Model/User';
import { AuthService } from '../Services/auth.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  
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
  public isUserLoggedin: boolean = false;
  public IsNoteBookSelected: boolean = false;
  public selectedNoteBook!: Notebook;
  public Notes: Note[] = [];
  public checkVisible: boolean = false;
  public nextNotebookId: number;
  public nextNoteId: number;
  public editNoteId: number = 0;
  public nextWeekplanId: number = 2;
  public editnoteText: string = "";
  public editNoteInput: string = "";
  public notebookNameVisible: boolean = true;
  public users: User[] = [];
  public searchInput: string = "";
  public searchNoteInput: string = "";
  public fileUpload: File;
  public noteInput: string = "";
  public SortbyParam: string = "CreatedDate";
  public SortNotebyParam: string = "CreatedDate";
  public SortNoteDirection: string = "asc";
  public SortDirection: string = "desc";
  public statusShared: boolean = false;
  public screenHeight: number;
  public screenWidth: number;
  public mobileView: boolean = false;
  public selectedSticker: string = "none";
  public stickerText: string = "";
  public searchStickerInput: string = "";
  public stickerFilter: string = "";
  public isEdit: boolean = false;
  public week: string[] = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"];
  public Notebooks: Array<Notebook> = [];
  public isNotebookDetail: boolean = false;
  public activeNotes: Array<Note> = [];
  public stickerType: string = "none";
  public dayOfWeek = { "Sunday": 0, "Monday": 1, "Tuesday": 2, "Wednesday": 3, "Thursday": 4, "Friday": 5, "Saturday": 6 };

  public stickerTypeInt = {
    "none": 0,
    "primary" :1,
    "secondary" : 2,
    "success" : 3,
    "warning" : 4,
    "danger" : 5
  };

  public stickerTypeString = ["none",
    "primary",
    "secondary",
    "success",
    "warning",
    "danger"];
  
  //public shareStatus = {
  //  0: 'Public',
  //  1: 'Private',
  //  2: 'Shared'
  //};
  public notebookType = {
    1: "Notebook",
    2: "Weekly Planner",
    3: "Checklist",
    4: "Image Album"
  }

  constructor(private auth: AuthService, private router: Router) {

    if (auth.isLoggedIn()) {
      this.router.navigate(['appuser']);
    }
    this.Notes = [];
    this.Notebooks = [];
    this.nextNotebookId = 1;
    this.nextNoteId = 1;
  
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
    console.log(this.screenWidth, this.screenHeight);
    if (this.screenWidth <= 600) {
      this.mobileView = true;
    }
    else {
      this.mobileView = false;
    }
  }

  onNoteBookSelect(id: number) {
   
    
    this.selectedNoteBook = this.Notebooks.find(x => x.id == id);

    this.updateNotes();
    this.IsNoteBookSelected = true;

    if (this.selectedNoteBook.shareStatus == 2) {
      this.statusShared = true;
    }
    else if (this.selectedNoteBook.shareStatus == 1) {
      this.statusShared = false;
    }
  }


  public onAddNoteBook(type: number) {
    
    this.Notebooks.push({
      id: this.nextNotebookId,
      name: `New Notebook`,
      notebookType: type,
      shareStatus: 0,
      createdDate: new Date(),
      modifiedDate: new Date(),
      imageCount: 0,
      textCount: 0,
      checkedCount: 0,
      uncheckedCount: 0,
    });
    this.selectedNoteBook = this.Notebooks[this.Notebooks.length - 1];
    console.log(this.selectedNoteBook.id);
    this.selectedNoteBook.name = window.prompt("Please enter notebook name", this.selectedNoteBook.name) || this.selectedNoteBook.name;
    this.IsNoteBookSelected = true;
    //this.scroll();
    this.nextNotebookId += 1;
    this.updateNotes();
  }



  onDeleteAll() {
    if (window.confirm("Do you want to delete all notebooks and notes?")) {
      this.Notebooks = [];
      this.Notes = [];
    }
    this.IsNoteBookSelected = false; 
  }

  onDeleteNotebook() {
    if (window.confirm("Delete this notebook?")) {
      this.Notes = this.Notes.filter(x => x.notebookId != this.selectedNoteBook.id);

      const index = this.Notebooks.indexOf(this.selectedNoteBook);
      if (index > -1) {
        this.Notebooks.splice(index, 1);
      }
      this.IsNoteBookSelected = false;
    }

  }


 

  onEditNotebookName() {
    this.selectedNoteBook.name = window.prompt("Please enter notebook name", this.selectedNoteBook.name) || this.selectedNoteBook.name;
    this.Notebooks.find(x => x.id == this.selectedNoteBook.id).name = this.selectedNoteBook.name;
  }

  onStickerFilter(filter: string) {
    if (filter != "") {
      this.activeNotes = this.Notes.filter(x => x.notebookId == this.selectedNoteBook.id);
      this.activeNotes = this.activeNotes.filter(x => x.stickerType == this.stickerTypeInt[filter]);
    }
    else {
      this.activeNotes = this.Notes.filter(x => x.notebookId == this.selectedNoteBook.id);

    }


  }

  onGoogleLogin() {
    this.auth.GoogleAuth();
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


  onNotebookDetail() {
    if (this.isNotebookDetail == true) { this.isNotebookDetail = false; }
    else { this.isNotebookDetail = true; }

  }




  //Notes Area

  onEditNote(id: number) {
    this.editnoteText = this.Notes.find(x => x.id == id).textNote;
    this.editNoteId = id;
    this.ChangeCheck(id);

  }

  onEditNoteSaveChanges() {

    this.Notes.find(x => x.id == this.editNoteId).textNote = this.editnoteText;
    this.Notes.find(x => x.id == this.editNoteId).modifiedDate = new Date();
    this.Notes.find(x => x.id == this.editNoteId).stickerType = this.stickerTypeInt[this.selectedSticker];
    this.Notes.find(x => x.id == this.editNoteId).stickerNote = this.stickerText;
   

    
  
    this.editNoteInput = "";
    this.editnoteText = "";
    this.updateNotes();
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
   

  }

  

  onDeleteNote(id: number) {

    if (this.Notes.find(x => x.id == id).isChecked == false) {

      this.selectedNoteBook.uncheckedCount -= 1;
    }
    else if (this.Notes.find(x => x.id == id).isChecked == true) {
      this.selectedNoteBook.checkedCount -= 1;
    }
    const index = this.Notes.indexOf(this.Notes.find(x => x.id == id));
    if (index > -1) {
      this.Notes.splice(index, 1);
    }
    this.updateNotes();

  }

  onAddSticker() {
   this.Notes.find(x => x.id == this.editNoteId).stickerType = 0;
    this.Notes.find(x => x.id == this.editNoteId).stickerNote = this.stickerText;
    this.Notes.find(x => x.id == this.editNoteId).modifiedDate = new Date();
   
    this.stickerText = "...";
    this.updateNotes();
  }


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
     

      if (this.selectedNoteBook.notebookType == 3) {
        this.Notes.push({
          id: this.nextNoteId,
          notebookId: this.selectedNoteBook.id,

          textNote: this.noteInput,
          createdDate: new Date(),
          stickerType: 0,
          isChecked: false,
          stickerNote: ""

        });
        this.selectedNoteBook.uncheckedCount += 1;
      }
      else {
        this.Notes.push({
          id: this.nextNoteId,
          notebookId: this.selectedNoteBook.id,

          textNote: this.noteInput,
          createdDate: new Date(),
          stickerType: 0,
          isChecked: false,
          stickerNote:""
        });
       
      }
      this.selectedNoteBook.modifiedDate = new Date();
      console.log(this.Notes);
      let el = document.getElementById("inputSubmit");
      el.focus();

      this.nextNoteId += 1;
      this.noteInput = "";
      //   this.scroll("notes_scroll");

      this.updateNotes();

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
    if (this.isEdit == true) {
      this.Notes.find(x => x.id == this.editWeekplanNote.id).textNote = this.editWeekplanNote.textNote;
      this.Notes.find(x => x.id == this.editWeekplanNote.id).stickerType = this.stickerTypeInt[this.selectedSticker];
      this.Notes.find(x => x.id == this.editWeekplanNote.id).stickerNote = this.editWeekplanNote.stickerNote;
      this.Notes.find(x => x.id == this.editWeekplanNote.id).header = this.editWeekplanNote.header;
      this.Notes.find(x => x.id == this.editWeekplanNote.id).hour = this.editWeekplanNote.hour;
      this.Notes.find(x => x.id == this.editWeekplanNote.id).modifiedDate = new Date();

    


    }
    else {
      this.Notes.push(
        {
          id: this.nextNoteId,
          notebookId: this.selectedNoteBook.id,
          createdDate: new Date(),
          textNote: this.editWeekplanNote.textNote,
          day: this.editWeekplanNote.day,
          stickerType: this.stickerTypeInt[this.selectedSticker],
          stickerNote: this.editWeekplanNote.stickerNote,
          hour: this.editWeekplanNote.hour,
          header: this.editWeekplanNote.header
        }
      );
      this.nextNoteId += 1;
   
    }
    this.updateNotes();
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
  
  }


}
