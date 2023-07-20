export interface Note {
  id?: number;
  createdDate?: Date;
  modifiedDate?: Date;
  notebookId: number;
  textNote?: string;
  noteType?: number;
  stickerType?: number;
  stickerNote?: string;
  isChecked?: boolean;
  header?: string;
  day?: number;
  hour?: string;
}
