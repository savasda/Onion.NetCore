import { Component, OnInit } from '@angular/core';
import { ManagerService } from '../../services/manager.service';
import { UserInterface } from '../../entities/typings';

@Component({
  selector: 'app-manager',
  templateUrl: './manager.component.html',
  styleUrls: ['./manager.component.less']
})
export class ManagerComponent implements OnInit {

  constructor(private _service: ManagerService) { }

  ngOnInit() {
  }

  greateUser() {
    const user: UserInterface = {
      id: 1,
      role: 0,
      name: 'newUser',
      password: '1234'
    };
    this._service.createNewUser(user).subscribe(data => {
      console.log(data);
    });
  }

}
