
export class LoginViewModel {
	public Email: string ;
	public Password: string ;
	public RememberMe: boolean ;

	public constructor(
		fields?: Partial<LoginViewModel>) {

		if (fields) {



			Object.assign(this, fields);
		}
	}
}
