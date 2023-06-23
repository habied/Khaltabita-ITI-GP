export class FeedBack{
    constructor(public userid:string="",public userName:String="", public chefId:string="",
         public rating:number=4, public review:String="", public date=new Date()){}
    }