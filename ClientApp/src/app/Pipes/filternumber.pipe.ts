import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filternumber'
})
export class FilternumberPipe implements PipeTransform {

  transform(value: any[], filterNumber: number, propName: string) {

    const resultArray = [];
    if (value) {
      if (value.length === 0 || filterNumber === 0 || propName === '') {
        return value;
      }
    }
    for (const item of value) {
      if (item[propName] == filterNumber) {
        resultArray.push(item);
      }
    }
    return resultArray;

  }
}
