
export class Proposal {
  constructor(
    public Id:Number,
    public Price:number,
    // public PrepTimeMin:Date,
    public Description:string,
    // public PrepTimeMin:number,
    // public Media:string,
    public PostId:Number,
    public ChefId:string,
    public datePosted:number,
    public chefName:string="",
    public chefRating:number=1,
    public chefPhoto:string="",
    ){}
}
