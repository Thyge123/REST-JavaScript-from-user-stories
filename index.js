const baseUri = "https://rest---javascript-from-user-stories.azurewebsites.net/api/Records"

Vue.createApp({
    data() {
        return {
            records: [],
            error: null,
            addData: { id: 0, title: "", artist: "", publication: "2025-08-28T00:00:00", duration: 0 },
            addMessage: "",
        }
    },
    async created() {
        // created() is a life cycle method, not an ordinary method
        // created() is called automatically when the page is loaded
        console.log("created method called")
        this.helperGetPosts(baseUri)
    },
    methods: {
        async helperGetPosts(uri) {
            try {
                const response = await axios.get(uri)
                this.records = await response.data
                this.error = null
            } catch (ex) {
                this.records = []
                this.error = ex.message
            }
        },  
        async AddRecords() {
            try {
                response = await axios.post(baseUri, this.addData)
                this.addMessage = "response " + response.status + " " + response.statusText
                this.helperGetPosts(baseUri)
            } catch (ex) {
                alert(ex.message)
            }
        },
        sortByTitle() {
            this.helperGetPosts(baseUri + "?sort_by=title")
        },
        sortByArtist() {
            this.helperGetPosts(baseUri + "?sort_by=artist")
        },
        sortByDuration() {
            this.helperGetPosts(baseUri + "?sort_by=duration")
        },
        sortByPublication() {
            this.helperGetPosts(baseUri + "?sort_by=publication")
        },
    }
}).mount("#app")