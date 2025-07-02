import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavbarComponent } from "./navbar/navbar.component";
import { FooterComponent } from "./footer/footer.component";
import { SideBarComponent } from "./side-bar/side-bar.component";
import { AjoutOffreFormComponent } from "./ajout-offre-form/ajout-offre-form.component";
import { LoginFormComponent } from "./login-form/login-form.component";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, NavbarComponent, FooterComponent, SideBarComponent, AjoutOffreFormComponent, LoginFormComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'GestionDeStage';
}
