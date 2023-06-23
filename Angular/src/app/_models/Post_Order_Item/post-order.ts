
import { Proposal } from "./Proposal";
import { Client } from "../client/client";

export class PostOrder {
  constructor(
              public PostID:Number=-1,
              public Description:string="",
              public FromPrice:number=0,
              public ToPrice:number=0,
              public PrepTime:Date=new Date(Date.now()),
              public Quantity:number=0,
              public QuantityUnit:string="",
              public UserId:string="",
              public UserName:string="",
              public UserAddress:string="",
              public date?:Date,
              public Proposals:Proposal[]=[],
              ){}
  }
