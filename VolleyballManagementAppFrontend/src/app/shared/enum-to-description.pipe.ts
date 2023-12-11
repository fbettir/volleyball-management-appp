import { Pipe, PipeTransform } from '@angular/core';



@Pipe({
  name: 'enumIntToDescription'
})
export class EnumIntToDescriptionPipe implements PipeTransform {

    // enum object on which you want this pipe to work
    transform(value: number, enumType: any): any{
      return enumType[value];
  }

}
