export interface AuthState {
  token?: string;
  username?: string;
  email?: string;
  firstName?: string;
  lastName?: string;
  isAdmin?: boolean;
  isLoggedIn: boolean;
}
