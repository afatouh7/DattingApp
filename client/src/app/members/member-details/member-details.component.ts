import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Member } from 'src/app/_model/member';
import { MembersService } from 'src/app/_Services/members.service';

@Component({
  selector: 'app-member-details',
  templateUrl: './member-details.component.html',
  styleUrls: ['./member-details.component.css']
})
export class MemberDetailsComponent implements OnInit {
member: Member;
  constructor(private memberService:MembersService,private route:ActivatedRoute) { }

  ngOnInit(): void {
    this,this.loadMember();
  }
  loadMember(){
    this.memberService.getMmber(this.route.snapshot.paramMap.get('username')).subscribe(member=>{
      this.member=member;
    })
  }
}
