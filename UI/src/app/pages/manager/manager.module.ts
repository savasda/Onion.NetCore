import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ManagerRoutingModule } from './manager-routing.module';
import { ManagerComponent } from './conatainers/manager/manager.component';
import { ServicesModule } from './services/services.module';


@NgModule({
  declarations: [ManagerComponent],
  imports: [
    CommonModule,
    ManagerRoutingModule,
    ServicesModule
  ]
})
export class ManagerModule { }
