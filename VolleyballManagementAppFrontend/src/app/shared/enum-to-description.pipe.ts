import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'enumToDescription'
})
export class EnumToDescriptionPipe implements PipeTransform {

    // enum object on which you want this pipe to work
    transform(value: number, e: any): any {
      return Object.values(e)[value];
  }

}
