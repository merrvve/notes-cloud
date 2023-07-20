export interface Notebook {
  id: number;
  cloudId?: number;
  name: string;
  notebookType: number;
  createdDate: Date;
  modifiedDate?: Date;
  textCount?: number;
  checkedCount?: number;
  uncheckedCount?: number;
  shareStatus?: number;
  imageCount?: number;
  addedBy?: number;

}
