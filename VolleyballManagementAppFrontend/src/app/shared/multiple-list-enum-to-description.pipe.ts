import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'multipleListEnumToDescription'
})
export class MultipleListEnumToDescriptionPipe implements PipeTransform {

  transform(values: number[], enumType: any): any{
    return values.map(value => enumType[value]).join(", ");
  }

}
