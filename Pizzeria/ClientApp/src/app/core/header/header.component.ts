import {Component} from '@angular/core';
import {RecipeService} from '../../recipes/recipe.service';
import {AuthService} from '../../auth/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html'
})
export class HeaderComponent {
  constructor(private recipeService: RecipeService,
              private authService: AuthService) {
  }

  private onSaveData() {
  }

  private onFetchData() {
  }

  isAuthenticated() {
    return this.authService.isAuthenticated();
  }

  getUserName() {
    if (this.authService.isAuthenticated() && this.authService.getUserInfo()) {
      console.log(this.authService.getUserInfo());
      return this.authService.getUserInfo()['FirstName'];
    }
    return null;
  }
}
