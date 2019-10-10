export interface AuthState {
  token?: string;
  firstName?:string;
  lastName?:string;
  isAdmin?: boolean;
  isLoggedIn: boolean;
}
