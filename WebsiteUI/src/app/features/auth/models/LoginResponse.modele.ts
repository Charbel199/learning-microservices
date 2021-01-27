export interface LoginResponse {
  // tslint:disable-next-line:variable-name
  access_token : string;
  // tslint:disable-next-line:variable-name
  expires_in: number;
  // tslint:disable-next-line:variable-name
  token_type: string;
  scope: string;
}
