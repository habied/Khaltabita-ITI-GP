
export class AddPostDto {

  constructor(
              public Description:string="",
              public FromPrice:number=0,
              public ToPrice:number=0,
              public PrepTime:Date,
              public Quantity:number=0,
              public QuantityUnit:string="",
              public UserId:string="",
              ){}
  }
