import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { NavComponent } from './nav/nav.component';
import { ModalComponent } from './modal/modal.component';

@NgModule({
  declarations: [
    NavComponent,
    ModalComponent
  ],
  exports: [
    NavComponent,
    ModalComponent
  ],
  imports: [
    BrowserModule,
    NgbModule,
  ],
  providers: [
    NgbModal,
  ],
})
export class ComponentsModule { }
