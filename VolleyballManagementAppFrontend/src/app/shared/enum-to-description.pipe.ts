import { Pipe, PipeTransform } from '@angular/core';

export enum TicketPass {
  Ticket = "Ticket",
  StudentTicket = "StudentTicket",
  Pass = "Pass",
  StudentPass = "StudentPass",
}

@Pipe({
  name: 'enumIntToDescription'
})
export class EnumIntToDescriptionPipe implements PipeTransform {

    // enum object on which you want this pipe to work
    transform(value: TicketPass,): any{
      return TicketPass[value];
  }

}
