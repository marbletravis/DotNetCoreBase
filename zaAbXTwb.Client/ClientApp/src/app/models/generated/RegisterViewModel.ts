
export class RegisterViewModel {
	public ConfirmPassword: string ;
	public Email: string ;
	public Password: string ;

	public constructor(
		fields?: Partial<RegisterViewModel>) {

		if (fields) {



			Object.assign(this, fields);
		}
	}
}
