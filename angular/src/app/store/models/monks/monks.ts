import { ABP } from '@abp/ng.core';


export namespace Monks {
  export interface State {
    monks: Response;
  }

  export interface Response {
    items: Monk[];
    totalCount: number;
  }



  export interface MonksQueryParams extends ABP.PageQueryParams {
    filterText?: string;
    imgPath?: string;
    fullName?: string;
    holyName?: string;
    homeTown?: string;
    permanentAdress?: string;
    dateOfBirthMax?: string;
    dateOfBirthMin?: string;
    dateOfBaptismMax?: string;
    dateOfBaptismMin?: string;
    placeOfBaptism?: string;
    dateOfConfirmationMax?: string;
    dateOfConfirmationMin?: string;
    placeOfConfirmation?: string;
    email?: string;
    phoneNumber?: string;
    father_FullName?: string;
    father_HolyName?: string;
    mother_FullName?: string;
    mother_HolyName?: string;

  }

  export interface Monk {
    id: string;
    imgPath: string;
    fullName: string;
    holyName: string;
    homeTown: string;
    permanentAdress: string;
    dateOfBirth: string;
    dateOfBaptism: string;
    placeOfBaptism: string;
    dateOfConfirmation: string;
    placeOfConfirmation: string;
    email: string;
    phoneNumber: string;
    father_FullName: string;
    father_HolyName: string;
    mother_FullName: string;
    mother_HolyName: string;

  }

  export interface MonkCreateUpdateDto {
    imgPath: string;
    fullName: string;
    holyName: string;
    homeTown: string;
    permanentAdress: string;
    dateOfBirth: string;
    dateOfBaptism: string;
    placeOfBaptism: string;
    dateOfConfirmation: string;
    placeOfConfirmation: string;
    email: string;
    phoneNumber: string;
    father_FullName: string;
    father_HolyName: string;
    mother_FullName: string;
    mother_HolyName: string;

  }
}
