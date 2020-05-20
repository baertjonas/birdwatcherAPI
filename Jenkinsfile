pipeline {
    agent {
        dockerfile {
            filename 'Dockerfile'
            additionalBuildArgs '-t myangular --no-cache'
        }
    }
    stages {
        stage('Build') {
            steps {
                echo "Building..."
            }
        }
    }    
}