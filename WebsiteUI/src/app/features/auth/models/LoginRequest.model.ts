export interface LoginRequest {
  // tslint:disable-next-line:variable-name
  client_id: string;
  // tslint:disable-next-line:variable-name
  client_secret: string;
  // tslint:disable-next-line:variable-name
  grant_type: string;
  scope: string;
}
