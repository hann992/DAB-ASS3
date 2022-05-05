

const society_coll = {
	society_id: int,
	society_CVR: int,
	society_name: string,
	society_activity: string,
	society_member_count: int,
	chairman: { 
		chairman_name: string, 
		chairman_CPR: int,
		chairman_address: string
	}
	key_responsible: { 
		key_responsible_name: string, key_responsible_CPR: int,
		key_responsible_address: string,
		key_responsible_phone: int,
		key_responsible_photo_id_number: int
	}
}


const booking_coll = {
	booking_from: Date,
	booking_to: Date,
	society_id: int,
	room_id: int
}


const location_coll = {
	location_id: int,
	location_address: string,
	location_zipcode: int,
	location_name: string,
	location_access: [
		{ 
			location_access_id: int,
		  	location_access_code: int,
		  	location_key_pickup_address: string
		}
	]
	location_properties: [ { location_property_id: int} ]
}

const room_coll = {
	room_id: int,
	room_location_id: int,
	room_name: string,
	room_capacity: int
	room_properties: [ { room_property_id: int } ]
}


const room_properties = {
	room_property_id: int,
	room_property_name: string,
	room_ids: [ {room_id: int} ]
}


const location_properties = {
	location_property_id: int,
	location_property_name: string,
	location_ids: [ {location_id: int} ]
}