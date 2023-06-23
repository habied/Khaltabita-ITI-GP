export class RegisterChefDto{
    constructor(
        public mobile:string,
        public name:string ,
        public email:string ,
        public gender:string,
        public password:string ,
        public confirmPassword: string,
        public address:string ,
        public media:string,
        ){}
  }

